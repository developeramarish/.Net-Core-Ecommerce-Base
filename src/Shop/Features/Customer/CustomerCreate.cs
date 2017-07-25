using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Interfaces;
using Shop.Extensions;
using Shop.Infrastructure.Data;

namespace Shop.Features.Customer
{
    public class CustomerCreate
    {
        public class Command : IRequest<string>
        {
            public string Title { get; set; }
            public string Name { get; set; }
            public string EmailAddress { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string BasketReference { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotNull()
                    .WithMessage("Title cannot be empty")
                    .Length(1, 25)
                    .WithMessage("Title too long");
                RuleFor(x => x.Name)
                    .NotNull()
                    .WithMessage("Name cannot be empty")
                    .Length(1, 250)
                    .WithMessage("Name too long");
                RuleFor(x => x.EmailAddress)
                    .NotNull()
                    .WithMessage("Email address cannot be empty")
                    .EmailAddress()
                    .WithMessage("Must be a valid email address");
                RuleFor(x => x.Password).Password();
                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password)
                    .WithMessage("Passwords do not match");
            }
        }

        public class Handler : IAsyncRequestHandler<Command, string>
        {
            private readonly ShopContext _db;
            private readonly IReferenceGenerator _referenceGenerator;
            private readonly IPasswordHasher _passwordHasher;

            public Handler(ShopContext db, IReferenceGenerator referenceGenerator, IPasswordHasher passwordHasher)
            {
                _db = db;
                _referenceGenerator = referenceGenerator;
                _passwordHasher = passwordHasher;
            }

            public async Task<string> Handle(Command message)
            {

                if (await _db.Customers.Where(x => x.EmailAddress == message.EmailAddress).AnyAsync())
                {
                    throw new ValidationException("Email Address already taken");
                }

                var salt = Guid.NewGuid().ToByteArray();
                var customer = new Core.Entites.Customer
                {
                    Title = message.Title,
                    Name = message.Name,
                    EmailAddress = message.EmailAddress,
                    PasswordHash = _passwordHasher.Hash(message.Password, salt),
                    PasswordSalt = salt
                };

                customer.CreateReference(_referenceGenerator);

                await _db.Customers.AddAsync(customer);

                await _db.SaveChangesAsync();

                return customer.CustomerReference;
            }
        }

        
    }
}
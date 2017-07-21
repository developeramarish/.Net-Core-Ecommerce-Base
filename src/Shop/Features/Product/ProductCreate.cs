using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Shop.Core.Interfaces;
using Shop.Infrastructure.Data;

namespace Shop.Features.Product
{
    public class ProductCreate
    {
        public class Command : IRequest<string>
        {
            public string ProductName { get; set; }
            public string ProductShortDescription { get; set; }
            public string ProductDescription { get; set; }
            public decimal Price { get; set; }
            public decimal TaxRate { get; set; }
            public bool AvailableForOrder { get; set; }
            public bool Configureable { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductName).NotEmpty().NotNull();
                RuleFor(x => x.ProductShortDescription).NotEmpty().NotNull();
                RuleFor(x => x.ProductDescription).NotEmpty().NotNull();
                RuleFor(x => x.Price).NotEmpty().NotNull();
                RuleFor(x => x.TaxRate).NotEmpty().NotNull();
            }
        }

        public class Handler : IAsyncRequestHandler<Command, string>
        {
            private readonly ShopContext _db;
            private readonly IReferenceGenerator _referenceGenerator;

            public Handler(ShopContext db, IReferenceGenerator referenceGenerator)
            {
                _db = db;
                _referenceGenerator = referenceGenerator;
            }

            public async Task<string> Handle(Command message)
            {
                var product = Mapper.Map<Command, Core.Entites.Product>(message);

                product.CreateReference(_referenceGenerator);

                await _db.Products.AddAsync(product);

                await _db.SaveChangesAsync();

                return product.ProductReference;
            }
        }

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Command, Core.Entites.Product>(MemberList.None);
            }
        }
    }
}

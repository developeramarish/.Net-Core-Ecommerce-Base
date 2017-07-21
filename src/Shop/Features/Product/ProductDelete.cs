using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Data;

namespace Shop.Features.Product
{
    public class ProductDelete
    {
        #region Query
        public class Query : IRequest<Command>
        {
            public string ProductReference { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.ProductReference).NotNull();
            }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Command>
        {

            private readonly ShopContext _db;

            public QueryHandler(ShopContext db)
            {
                _db = db;
            }
            
            public async Task<Command> Handle(Query query)
            {
                var product = await 
                    _db.Products
                        .Where(p => p.ProductReference == query.ProductReference)
                        .FirstOrDefaultAsync();

                return Mapper.Map<Command>(product);
            }
        }

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Core.Entites.Product, Command>(MemberList.None);
            }
        }

        #endregion

        #region Command
        public class Command : IRequest<bool>
        {
            public string ProductReference { get; set; }
            public string ProductName { get; set; }
            public string Price { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductReference).NotEmpty().NotNull();
            }
        }

        public class CommandHandler : IAsyncRequestHandler<Command, bool>
        {
            private readonly ShopContext _db;

            public CommandHandler(ShopContext db)
            {
                _db = db;
            }

            public async Task<bool> Handle(Command message)
            {
                var product = await
                    _db.Products
                        .Where(p => p.ProductReference == message.ProductReference)
                        .FirstOrDefaultAsync();

                if (product == null)
                    return false;

                product.SoftDelete();

                return await _db.SaveChangesAsync() > 0;
            }
        }

        #endregion
    }
}
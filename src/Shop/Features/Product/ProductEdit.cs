using FluentValidation;
using MediatR;
using Shop.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Shop.Features.Product
{
    public class ProductEdit
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
            public string ProductShortDescription { get; set; }
            public string ProductDescription { get; set; }
            public decimal Price { get; set; }
            public decimal TaxRate { get; set; }
            public bool AvailableForOrder { get; set; }
            public bool Configureable { get; set; }
        }

        #endregion
    }
}
using FluentValidation;
using MediatR;
using Shop.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Interfaces;
using Shop.Infrastructure.Data.Extensions;

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

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductReference).NotEmpty().NotNull();
                RuleFor(x => x.ProductName).NotEmpty().NotNull();
                RuleFor(x => x.ProductShortDescription).NotEmpty().NotNull();
                RuleFor(x => x.ProductDescription).NotEmpty().NotNull();
                RuleFor(x => x.Price).NotEmpty().NotNull();
                RuleFor(x => x.TaxRate).NotEmpty().NotNull();
            }
        }

        public class Handler : IAsyncRequestHandler<Command, bool>
        {

            private readonly ShopContext _db;

            public Handler(ShopContext db)
            {
                _db = db;
            }

            public async Task<bool> Handle(Command message)
            {
                var updatedProduct = Mapper.Map<Core.Entites.Product>(message);

                var currentProduct = await _db
                    .Products
                        .Active()
                        .FirstOrDefaultAsync(p => p.ProductReference == message.ProductReference);

                if (currentProduct == null) return false;

                var isDirty = new MapToExisting().Map(updatedProduct, currentProduct);

                return !isDirty || await _db.SaveChangesAsync() > 0;
            }

            

            private class MapToExisting : IMapToExisting<Core.Entites.Product, Core.Entites.Product>
            {
                public bool Map(Core.Entites.Product source, Core.Entites.Product target)
                {
                    target.MarkClean();

                    target.ProductName = source.ProductName;
                    target.ProductShortDescription = source.ProductShortDescription;
                    target.ProductDescription = source.ProductDescription;
                    target.Price = source.Price;
                    target.TaxRate = source.TaxRate;
                    target.ShippingWeightKg = source.ShippingWeightKg;
                    target.AvailableForOrder = source.AvailableForOrder;
                    target.Configureable = source.Configureable;

                    if (target.IsDirty)
                        target.MarkUpdated();

                    return target.IsDirty;
                }
            }
        }

        #endregion

        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Core.Entites.Product, Command>(MemberList.None);
                CreateMap<Command, Core.Entites.Product>(MemberList.None);
            }
        }
    }
}
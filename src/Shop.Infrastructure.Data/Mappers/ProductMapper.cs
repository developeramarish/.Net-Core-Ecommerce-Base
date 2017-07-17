using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class ProductMapper : IMapToExisting<Product, Product>
    {
        public bool Map(Product source, Product target)
        {
            target.MarkClean();

            target.ProductName = source.ProductName;
            target.ProductShortDescription = source.ProductShortDescription;
            target.ProductDescription = source.ProductDescription;
            target.PricePreTax = source.PricePreTax;
            target.ShippingWeightKg = source.ShippingWeightKg;
            target.AvailableForOrder = source.AvailableForOrder;
            target.Configureable = source.Configureable;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
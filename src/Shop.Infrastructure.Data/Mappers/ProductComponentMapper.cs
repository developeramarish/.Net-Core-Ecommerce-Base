using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class ProductComponentMapper : IMapToExisting<ProductComponent, ProductComponent>
    {
        public bool Map(ProductComponent source, ProductComponent target)
        {
            target.MarkClean();

            target.ProductComponentName = source.ProductComponentName;
            target.ProductComponentDescription = source.ProductComponentDescription;
            target.ComponentSlot = source.ComponentSlot;
            target.PricePreTax = source.PricePreTax;
            target.AvailableForOrder = source.AvailableForOrder;
            target.ShippingWeightKg = source.ShippingWeightKg;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
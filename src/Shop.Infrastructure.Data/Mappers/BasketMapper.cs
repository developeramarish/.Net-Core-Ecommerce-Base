using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class BasketMapper : IMapToExisting<Basket, Basket>
    {
        public bool Map(Basket source, Basket target)
        {
            target.MarkClean();

            target.ShippingMethod = source.ShippingMethod;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
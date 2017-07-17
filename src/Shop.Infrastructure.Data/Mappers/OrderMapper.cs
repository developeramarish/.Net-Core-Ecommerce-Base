using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class OrderMapper : IMapToExisting<Order, Order>
    {
        public bool Map(Order source, Order target)
        {
            target.MarkClean();

            //No components mapped at this time

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
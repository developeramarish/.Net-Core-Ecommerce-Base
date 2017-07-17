using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class ShippingDetailsMapper : IMapToExisting<ShippingDetails, ShippingDetails>
    {
        public bool Map(ShippingDetails source, ShippingDetails target)
        {
            target.MarkClean();

            target.ShippingProvider = source.ShippingProvider;
            target.ShippingMethod = source.ShippingMethod;
            target.TrackingReference = source.TrackingReference;
            target.TrackingUrl = source.TrackingUrl;
            target.EstimatedShippingDate = source.EstimatedShippingDate;
            target.ShippedDate = source.ShippedDate;
            target.EstimatedDeliveryDate = source.EstimatedDeliveryDate;
            target.DeliveredDate = source.DeliveredDate;
            target.PricePaid = source.PricePaid;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
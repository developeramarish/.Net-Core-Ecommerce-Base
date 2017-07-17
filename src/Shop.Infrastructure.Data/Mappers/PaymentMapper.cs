using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class PaymentMapper : IMapToExisting<Payment, Payment>
    {
        public bool Map(Payment source, Payment target)
        {
            target.MarkClean();

            target.PaymentServiceProvider = source.PaymentServiceProvider;
            target.PspChargeId = source.PspChargeId;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
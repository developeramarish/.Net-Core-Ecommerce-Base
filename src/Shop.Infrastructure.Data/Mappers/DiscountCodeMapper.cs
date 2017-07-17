using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class DiscountCodeMapper : IMapToExisting<DiscountCode, DiscountCode>
    {
        public bool Map(DiscountCode source, DiscountCode target)
        {
            target.MarkClean();

            target.Code = source.Code;
            target.DiscountCodeType = source.DiscountCodeType;
            target.DiscountAmount = source.DiscountAmount;
            target.ClaimLimit = source.ClaimLimit;
            target.NumberClaimed = source.NumberClaimed;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
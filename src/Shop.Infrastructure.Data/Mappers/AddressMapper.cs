using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class AddressMapper : IMapToExisting<Address, Address>
    {
        public bool Map(Address source, Address target)
        {
            target.MarkClean();

            target.AddressLine1 = source.AddressLine1;
            target.AddressLine2 = source.AddressLine2;
            target.AddressLine3 = source.AddressLine3;
            target.AddressLine4 = source.AddressLine4;
            target.Postcode = source.Postcode;
            target.County = source.County;
            target.CountryCode = source.CountryCode;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
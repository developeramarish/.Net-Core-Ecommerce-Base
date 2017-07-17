using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class CustomerMapper : IMapToExisting<Customer, Customer>
    {
        public bool Map(Customer source, Customer target)
        {
            target.MarkClean();
            target.Title = source.Title;
            target.Name = source.Name;
            target.EmailAddress = source.EmailAddress;
            target.TelephoneNumber = source.TelephoneNumber;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
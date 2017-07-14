using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Customer : LifetimeBase, IReferenceable<Customer>
    {

        private string _title;
        private string _name;
        private string _emailAddress;
        private string _telephoneNumber;

        [Key]
        public int CustomerId { get; set; }
        public string CustomerReference { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;

                IsDirty = true;
                _title = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;

                IsDirty = true;
                _name = value;
            }
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                if (_emailAddress == value) return;

                IsDirty = true;
                _emailAddress = value;
            }
        }
        public string TelephoneNumber
        {
            get => _telephoneNumber;
            set
            {
                if (_telephoneNumber == value) return;

                IsDirty = true;
                _telephoneNumber = value;
            }
        }
        public List<Address> Addresses { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<Order> Orders { get; set; }
        public List<Basket> Baskets { get; set; }



        public Customer CreateReference(IReferenceGenerator referenceGenerator)
        {
            CustomerReference = referenceGenerator.CreateReference("C-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
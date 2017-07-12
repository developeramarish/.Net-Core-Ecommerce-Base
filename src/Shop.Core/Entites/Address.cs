using System;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Address : LifetimeBase, IReferenceable<Address>
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _addressLine3;
        private string _addressLine4;
        private string _postcode;
        private string _county;
        private string _countryCode;
        private string _udprn;

        [Key]
        public int AddressId { get; set; }
        public string AddressReference { get; set; }

        public string AddressLine1
        {
            get => _addressLine1;
            set
            {
                if (_addressLine1 == value) return;
                _addressLine1 = value;
                IsDirty = true;
            }
        }
        public string AddressLine2
        {
            get => _addressLine2;
            set
            {
                if (_addressLine2 == value) return;
                _addressLine2 = value;
                IsDirty = true;
            }
        }
        public string AddressLine3
        {
            get => _addressLine3;
            set
            {
                if (_addressLine3 == value) return;
                _addressLine3 = value;
                IsDirty = true;
            }
        }
        public string AddressLine4
        {
            get => _addressLine4;
            set
            {
                if (_addressLine4 == value) return;
                _addressLine4 = value;
                IsDirty = true;
            }
        }
        public string Postcode
        {
            get => _postcode;
            set
            {
                if (_postcode == value) return;
                _postcode = value;
                IsDirty = true;
            }
        }
        public string County
        {
            get => _county;
            set
            {
                if (_county == value) return;
                _county = value;
                IsDirty = true;
            }
        }
        public string CountryCode
        {
            get => _countryCode;
            set
            {
                if (_countryCode == value) return;
                _countryCode = value;
                IsDirty = true;
            }
        }
        public string Udprn
        {
            get => _udprn;
            set
            {
                if (_udprn == value) return;
                _udprn = value;
                IsDirty = true;
            }
        }
        
        public Address()
        {
            AddressId = 0;
            AddressReference = string.Empty;

            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            AddressLine4 = string.Empty;
            Postcode = string.Empty;
            County = string.Empty;
            CountryCode = string.Empty;
            Udprn = string.Empty;
            
        }

        public Address CreateReference(IReferenceGenerator referenceGenerator)
        {
            AddressReference = referenceGenerator.CreateReference("A-", Constants.Constants.ReferenceLength);

            return this;
        }

    }
}
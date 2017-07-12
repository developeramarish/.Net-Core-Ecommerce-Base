using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Product : LifetimeBase, IReferenceable<Product>
    {

        private string _productName;
        private string _productDescription;
        private string _productShortDescription;
        private bool _availableForOrder;
        private decimal _pricePreTax;

        [Key]
        public int ProductId { get; set; }
        public string ProductReference { get; set; }

        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName == value) return;

                IsDirty = true;
                _productName = value;
            }
        }
        public string ProductShortDescription
        {
            get => _productShortDescription;
            set
            {
                if (_productShortDescription == value) return;

                IsDirty = true;
                _productShortDescription = value;
            }
        }
        public string ProductDescription
        {
            get => _productDescription;
            set
            {
                if (_productDescription == value) return;

                IsDirty = true;
                _productDescription = value;
            }
        }
        public List<Media> Media { get; set; }

        public List<ProductComponent> ProductComponents { get; set; }


        public decimal PricePreTax
        {
            get => _pricePreTax;
            set
            {
                if (_pricePreTax == value) return;

                IsDirty = true;
                _pricePreTax = value;
            }
        }

        public bool AvailableForOrder
        {
            get => _availableForOrder;
            set
            {
                if (_availableForOrder == value) return;

                IsDirty = true;
                _availableForOrder = value;
            }
        }
        public bool Configureable
        {
            get => _availableForOrder;
            set
            {
                if (_availableForOrder == value) return;

                IsDirty = true;
                _availableForOrder = value;
            }
        }
        
        public Product CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductReference = referenceGenerator.CreateReference("P-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
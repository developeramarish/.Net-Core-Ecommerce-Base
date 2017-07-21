using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Shop.Core.BaseObjects;
using Shop.Core.Enums;
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
        private decimal _taxRate;
        private decimal _shippingWeightKg;

        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductReference { get; set; }

        [Required]
        [StringLength(100)]
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

        [Required]
        [StringLength(500)]
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

        [Required]
        [StringLength(10000)]
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

        [DataType(DataType.Currency)]

        public decimal Price
        {
            get => _pricePreTax;
            set
            {
                if (_pricePreTax == value) return;

                IsDirty = true;
                _pricePreTax = value;
            }
        }
        public decimal TaxRate
        {
            get => _taxRate;
            set
            {
                if (_taxRate == value) return;

                IsDirty = true;
                _taxRate = value;
            }
        }
        public decimal ShippingWeightKg
        {
            get => _shippingWeightKg;
            set
            {
                if (_shippingWeightKg == value) return;

                IsDirty = true;
                _shippingWeightKg = value;
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
        public List<ComponentSlot> ComponentSlots { get; set; }
        public List<ProductComponentCompatibility> CompatibleComponents { get; set; }

        public Product()
        {
            ProductId = 0;
            ProductReference = string.Empty;

            Price = 0.0M;
            ShippingWeightKg = 0.0M;

            Media = new List<Media>();
            CompatibleComponents = new List<ProductComponentCompatibility>();
            ComponentSlots = new List<ComponentSlot>();
        }

        public string CoverImageUrl => Media.OrderBy(x => x.Index).FirstOrDefault()?.Url;

        public Product CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductReference = referenceGenerator.CreateReference("P-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
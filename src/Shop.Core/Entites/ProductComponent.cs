using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ProductComponent : LifetimeBase, IReferenceable<ProductComponent>
    {
        private string _productComponentName;
        private string _productComponentDescription;
        private ComponentSlot _componentSlot;
        private bool _availableForOrder;
        private decimal _pricePreTax;
        private decimal _shippingWeightKg;
        private decimal _taxRate;


        [Key]
        public int ProductComponentId { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductComponentReference { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductComponentName
        {
            get => _productComponentName;
            set
            {
                if (_productComponentName == value) return;

                IsDirty = true;
                _productComponentName = value;
            }
        }

        [Required]
        [StringLength(10000)]
        public string ProductComponentDescription
        {
            get => _productComponentDescription;
            set
            {
                if (_productComponentDescription == value) return;

                IsDirty = true;
                _productComponentDescription = value;
            }
        }
        
        public List<Media> Media { get; set; }

        public ComponentSlot ComponentSlot
        {
            get => _componentSlot;
            set
            {
                if (_componentSlot == value) return;

                IsDirty = true;
                _componentSlot = value;
            }
        }

        [DataType(DataType.Currency)]
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

        public ProductComponent()
        {
            ProductComponentId = 0;
            ProductComponentReference = string.Empty;

            Media = new List<Media>();
        }

        public decimal Price() => PricePreTax + (PricePreTax * TaxRate);

        public ProductComponent CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductComponentReference = referenceGenerator.CreateReference("PC-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
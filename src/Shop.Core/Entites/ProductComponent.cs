using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Enums;
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

        [Key]
        public int ProductComponentId { get; set; }
        public string ProductComponentReference { get; set; }

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
            ComponentSlot = ComponentSlot.Unknown;
        }

        public ProductComponent CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductComponentReference = referenceGenerator.CreateReference("PC-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
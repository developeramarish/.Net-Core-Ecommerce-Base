using System;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Enums;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ShippingDetails : LifetimeBase, IReferenceable<ShippingDetails>
    {
        private ShippingProvider _shippingProvider;
        private ShippingMethod _shippingMethod;
        private DateTime? _shippedDate;
        private DateTime? _deliveredDate;
        private DateTime? _estimatedDeliveryDate;
        private DateTime? _estimatedShippingDeliveryDate;
        private string _trackingReference;
        private string _trackingUrl;
        private decimal _pricePaid;

        [Key]
        public int ShippingDetailsId { get; set; }
        public string ShippingDetailsReference { get; set; }

        public ShippingProvider ShippingProvider
        {
            get => _shippingProvider;
            set
            {
                if (_shippingProvider == value) return;

                IsDirty = true;
                _shippingProvider = value;
            }
        }
        public ShippingMethod ShippingMethod
        {
            get => _shippingMethod;
            set
            {
                if (_shippingMethod == value) return;

                IsDirty = true;
                _shippingMethod = value;
            }
        }
        public string TrackingReference
        {
            get => _trackingReference;
            set
            {
                if (_trackingReference == value) return;

                IsDirty = true;
                _trackingReference = value;
            }
        }
        public string TrackingUrl
        {
            get => _trackingUrl;
            set
            {
                if (_trackingUrl == value) return;

                IsDirty = true;
                _trackingUrl = value;
            }
        }

        public DateTime? EstimatedShippingDate
        {
            get => _estimatedShippingDeliveryDate;
            set
            {
                if (_estimatedShippingDeliveryDate == value) return;

                IsDirty = true;
                _estimatedShippingDeliveryDate = value;
            }
        }
        public DateTime? ShippedDate
        {
            get => _shippedDate;
            set
            {
                if (_shippedDate == value) return;

                IsDirty = true;
                _shippedDate = value;
            }
        }

        public DateTime? EstimatedDeliveryDate
        {
            get => _estimatedDeliveryDate;
            set
            {
                if (_estimatedDeliveryDate == value) return;

                IsDirty = true;
                _estimatedDeliveryDate = value;
            }
        }
        public DateTime? DeliveredDate
        {
            get => _deliveredDate;
            set
            {
                if (_deliveredDate == value) return;

                IsDirty = true;
                _deliveredDate = value;
            }
        }

        public decimal PricePaid
        {
            get => _pricePaid;
            set
            {
                if (_pricePaid == value) return;

                IsDirty = true;
                _pricePaid = value;
            }
        }

        public ShippingDetails()
        {
            ShippingDetailsId = 0;
            ShippingDetailsReference = string.Empty;

            ShippingProvider = ShippingProvider.Unknown;
            ShippingMethod = ShippingMethod.Unknown;

            PricePaid = 0.0M;
        }

        public ShippingDetails CreateReference(IReferenceGenerator referenceGenerator)
        {
            ShippingDetailsReference = referenceGenerator.CreateReference("S-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
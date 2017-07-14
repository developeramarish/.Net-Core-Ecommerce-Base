using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Enums;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Payment : LifetimeBase, IReferenceable<Payment>
    {
        private PaymentServiceProvider _paymentServiceProvider;
        private string _pspChargeId;

        [Key]
        public int PaymentId { get; set; }
        public string PaymentReference { get; set; }

        public PaymentServiceProvider PaymentServiceProvider
        {
            get => _paymentServiceProvider;
            set
            {
                if (_paymentServiceProvider == value) return;

                IsDirty = true;
                _paymentServiceProvider = value;
            }
        }
        public string PspChargeId
        {
            get => _pspChargeId;
            set
            {
                if (_pspChargeId == value) return;

                IsDirty = true;
                _pspChargeId = value;
            }
        }

        public Payment CreateReference(IReferenceGenerator referenceGenerator)
        {
            PaymentReference = referenceGenerator.CreateReference("PAY-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
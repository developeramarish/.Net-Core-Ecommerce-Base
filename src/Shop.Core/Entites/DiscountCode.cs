using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Enums;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class DiscountCode : LifetimeBase, IReferenceable<DiscountCode>
    {
        private string _code;
        private DiscountCodeType _discountCodeType;
        private decimal _discountAmount;
        private int _claimLimit;
        private int _numberClaimed;

        [Key]
        public int DiscountCodeId { get; set; }
        public string DiscountCodeReference { get; set; }

        public string Code
        {
            get => _code;
            set
            {
                if (_code == value) return;

                IsDirty = true;
                _code = value;
            }
        }

        public DiscountCodeType DiscountCodeType
        {
            get => _discountCodeType;
            set
            {
                if (_discountCodeType == value) return;

                IsDirty = true;
                _discountCodeType = value;
            }
        }
        public decimal DiscountAmount
        {
            get => _discountAmount;
            set
            {
                if (_discountAmount == value) return;

                IsDirty = true;
                _discountAmount = value;
            }
        }
        public int ClaimLimit
        {
            get => _claimLimit;
            set
            {
                if (_claimLimit == value) return;

                IsDirty = true;
                _claimLimit = value;
            }
        }
        public int NumberClaimed
        {
            get => _numberClaimed;
            set
            {
                if (_numberClaimed == value) return;

                IsDirty = true;
                _numberClaimed = value;
            }
        }

        public DiscountCode()
        {
            DiscountCodeId = 0;
            DiscountCodeReference = string.Empty;

            DiscountCodeType = DiscountCodeType.Unknown;
        }

        public DiscountCode CreateReference(IReferenceGenerator referenceGenerator)
        {
            DiscountCodeReference = referenceGenerator.CreateReference("D-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
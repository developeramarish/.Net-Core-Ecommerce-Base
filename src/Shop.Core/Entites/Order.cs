using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Order : LifetimeBase, IReferenceable<Order>
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [StringLength(25)]
        public string OrderReference { get; set; }

        public List<ProductConfiguration> Products { get; set; }
        public DiscountCode DiscountCode { get; set; }
        public ShippingDetails ShippingMethod { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public Payment Payment { get; set; }


        public Order()
        {
            OrderId = 0;
            OrderReference = string.Empty;

            Products = new List<ProductConfiguration>();
        }

        public Order CreateReference(IReferenceGenerator referenceGenerator)
        {
            OrderReference = referenceGenerator.CreateReference("B-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
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
        public string OrderReference { get; set; }
        public List<OrderProduct> Products { get; set; }
        public List<ProductConfiguration> ProductConfigurations { get; set; }
        public DiscountCode DiscountCode { get; set; }

        public ShippingDetails ShippingMethod { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public Order CreateReference(IReferenceGenerator referenceGenerator)
        {
            OrderReference = referenceGenerator.CreateReference("B-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
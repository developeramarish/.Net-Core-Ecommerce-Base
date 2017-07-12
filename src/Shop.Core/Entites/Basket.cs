using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Basket : LifetimeBase, IReferenceable<Basket>
    {

        [Key]
        public int BasketId { get; set; }
        public string BasketReference { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductConfiguration> ProductConfigurations { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public DiscountCode DiscountCode { get; set; }

        public Basket CreateReference(IReferenceGenerator referenceGenerator)
        {
            BasketReference = referenceGenerator.CreateReference("B-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
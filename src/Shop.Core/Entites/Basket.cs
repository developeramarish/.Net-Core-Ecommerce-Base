using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Enums;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class Basket : LifetimeBase, IReferenceable<Basket>
    {

        [Key]
        public int BasketId { get; set; }
        public string BasketReference { get; set; }
        public List<BasketProduct> Products { get; set; }
        public List<ProductConfiguration> ProductConfigurations { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public DiscountCode DiscountCode { get; set; }

        public Basket()
        {
            BasketId = 0;
            BasketReference = string.Empty;

            Products = new List<BasketProduct>();
            ProductConfigurations = new List<ProductConfiguration>();
            ShippingMethod = ShippingMethod.FirstClass;
            DiscountCode = null;
        }

        public Basket CreateReference(IReferenceGenerator referenceGenerator)
        {
            BasketReference = referenceGenerator.CreateReference("B-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
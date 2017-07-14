using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ProductConfiguration : LifetimeBase, IReferenceable<ProductConfiguration>
    {
        [Key]
        public int ProductConfigurationId { get; set; }
        public string ProductConfigurationReference { get; set; }

        public Product BaseProduct { get; set; }
        public List<ProductComponent> Components { get; set; }

        public ProductConfiguration CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductConfigurationReference = referenceGenerator.CreateReference(Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
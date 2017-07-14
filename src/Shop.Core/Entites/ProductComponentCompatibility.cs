using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ProductComponentCompatibility : LifetimeBase, IReferenceable<Product>
    {
        [Key]
        public int ProductComponentCompatibilityId { get; set; }
        public string ProductComponentCompatibilityReference { get; set; }

        public Product Product { get; set; }
        public ProductComponent Component { get; set; }


        public Product CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductComponentCompatibilityReference = referenceGenerator.CreateReference("P-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
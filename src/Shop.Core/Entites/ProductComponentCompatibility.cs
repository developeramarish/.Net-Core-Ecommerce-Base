using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ProductComponentCompatibility : LifetimeBase, IReferenceable<ProductComponentCompatibility>
    {
        [Key]
        public int ProductComponentCompatibilityId { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductComponentCompatibilityReference { get; set; }

        public Product Product { get; set; }
        public ProductComponent Component { get; set; }


        public ProductComponentCompatibility CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductComponentCompatibilityReference = referenceGenerator.CreateReference("PCC-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
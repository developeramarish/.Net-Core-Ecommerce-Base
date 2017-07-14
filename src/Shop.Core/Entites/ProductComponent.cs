using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ProductComponent : LifetimeBase, IReferenceable<ProductComponent>
    {
        [Key]
        public int ProductComponentId { get; set; }
        public string ProductComponentReference { get; set; }



        public ProductComponent CreateReference(IReferenceGenerator referenceGenerator)
        {
            ProductComponentReference = referenceGenerator.CreateReference("PC-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
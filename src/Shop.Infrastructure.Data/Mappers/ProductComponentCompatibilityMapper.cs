using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class ProductComponentCompatibilityMapper : IMapToExisting<ProductComponentCompatibility, ProductComponentCompatibility>
    {
        public bool Map(ProductComponentCompatibility source, ProductComponentCompatibility target)
        {
            target.MarkClean();

            //No components mapped at this time

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
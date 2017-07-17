using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class ProductConfigurationMapper: IMapToExisting<ProductConfiguration, ProductConfiguration>
    {
        public bool Map(ProductConfiguration source, ProductConfiguration target)
        {
            target.MarkClean();

            //No components mapped at this time

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class MediaMapper : IMapToExisting<Media, Media>
    {
        public bool Map(Media source, Media target)
        {
            target.MarkClean();

            target.MediaType = source.MediaType;
            target.Url = source.Url;
            target.Index = source.Index;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
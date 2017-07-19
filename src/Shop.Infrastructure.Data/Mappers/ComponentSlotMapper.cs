using Shop.Core.Entites;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Mappers
{
    public class ComponentSlotMapper : IMapToExisting<ComponentSlot, ComponentSlot>
    {
        public bool Map(ComponentSlot source, ComponentSlot target)
        {
            target.MarkClean();

            target.SlotName = source.SlotName;
            target.Required = source.Required;

            if (target.IsDirty)
                target.MarkUpdated();

            return target.IsDirty;
        }
    }
}
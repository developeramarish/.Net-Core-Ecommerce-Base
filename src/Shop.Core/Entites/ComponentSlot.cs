using System.ComponentModel.DataAnnotations;
using Shop.Core.BaseObjects;
using Shop.Core.Interfaces;

namespace Shop.Core.Entites
{
    public class ComponentSlot : LifetimeBase, IReferenceable<ComponentSlot>
    {

        private string _slotName;
        private bool _required;

        [Key]
        public int ComponentSlotId { get; set; }

        [Required]
        [StringLength(25)]
        public string ComponentSlotReference { get; set; }

        [Required]
        [StringLength(100)]
        public string SlotName
        {
            get => _slotName;
            set
            {
                if (_slotName == value) return;

                IsDirty = true;
                _slotName = value;
            }
        }

        public bool Required
        {
            get => _required;
            set
            {
                if (_required == value) return;

                IsDirty = true;
                _required = value;
            }
        }

        public ComponentSlot CreateReference(IReferenceGenerator referenceGenerator)
        {
            ComponentSlotReference = referenceGenerator.CreateReference("CS-", Constants.Constants.ReferenceLength);
            return this;
        }
    }
}
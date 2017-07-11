using System;
using Shop.Core.Interfaces;

namespace Shop.Core.BaseObjects
{
    public class LifetimeBase : ISoftDeletable, IDirty
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public LifetimeBase()
        {
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
            DateDeleted = null;
            IsDirty = false;
        }

        public void MarkUpdated()
        {
            DateUpdated = DateTime.UtcNow;
        }

        public void SoftDelete()
        {
            DateDeleted = DateTime.UtcNow;
        }

        public bool IsDirty { get; set; }

        public void MarkClean()
        {
            IsDirty = false;
        }
    }
}

using System;

namespace Shop.Core.Interfaces
{
    public interface ISoftDeletable
    {
        DateTime? DateDeleted { get; }
        void SoftDelete();
    }
}
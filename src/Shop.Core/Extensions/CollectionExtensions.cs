using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Core.Interfaces;

namespace Shop.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Active<T>(this ICollection<T> source) where T : ISoftDeletable
        {
            return source.Where(e => e.DateDeleted == null || e.DateDeleted > DateTime.UtcNow);
        }
    }
}
using System;
using System.Linq;
using Shop.Core.Interfaces;

namespace Shop.Infrastructure.Data.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Active<T>(this IQueryable<T> source) where T : class, ISoftDeletable
        {
            return source.Where(e => e.DateDeleted == null || e.DateDeleted > DateTime.UtcNow);
        }
    }
}
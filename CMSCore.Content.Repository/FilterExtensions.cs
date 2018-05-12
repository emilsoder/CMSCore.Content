using System;
using System.Collections.Generic;
using System.Linq;
using CMSCore.Content.Models;

namespace CMSCore.Content.Repository
{
    public static class FilterExtensions
    {
        public static IEnumerable<TEntity> ActiveOnly<TEntity>(this IEnumerable<TEntity> set) where TEntity : EntityBase
        {
            return set.Where(DefaultPredicate<TEntity>());
        }

        public static IEnumerable<TEntity> ActiveOnly<TEntity>(this IEnumerable<TEntity> set, string entityId)
            where TEntity : EntityBase
        {
            return set.Where(DefaultPredicate<TEntity>(entityId));
        }

        public static Func<T, bool> DefaultPredicate<T>() where T : EntityBase
        {
            return arg => arg.Hidden == false && arg.IsActiveVersion == true && arg.MarkedToDelete == false;
        }

        public static Func<T, bool> DefaultPredicate<T>(string entityId) where T : EntityBase
        {
            return arg => arg.Hidden == false && arg.IsActiveVersion == true && arg.MarkedToDelete == false &&
                          arg.EntityId == entityId;
        }
    }
}
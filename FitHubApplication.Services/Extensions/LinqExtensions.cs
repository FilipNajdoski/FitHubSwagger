using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FitHubApplication.Services.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IQueryable<T> WhereIf<T> (this IQueryable<T> query,  bool condition, Expression<Func<T, bool>> predicate)
        {
            if(condition)
            {
                return query.Where(predicate);
            }

            return query;
        }
    }
}
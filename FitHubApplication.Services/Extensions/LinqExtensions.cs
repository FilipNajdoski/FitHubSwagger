using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FitHubApplication.Services.Extensions
{
    public static class LinqExtensions
    {

        /// <summary>
        /// Returns a new <see cref="IEnumerable{T}"/> with removed duplacates by given predicate
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Filters a <see cref="IQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
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
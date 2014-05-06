using System;
using System.Collections.Generic;

namespace Monads
{
    public static class Querying
    {
        public static IEnumerable<R> SelectMany<A, R>(
            this IEnumerable<A> sequence,
            Func<A, IEnumerable<R>> function)
        {
            foreach (A outerItem in sequence)
                foreach (R innerItem in function(outerItem))
                    yield return innerItem;
        }

        public static IEnumerable<T> WhereHelper<T>(
            T item,
            Func<T, bool> predicate)
        {
            if (predicate(item))
                yield return item;
        }

        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> items,
            Func<T, bool> predicate)
        {
            return items.SelectMany(item => WhereHelper(item, predicate));
        }

        public static IEnumerable<R> SelectHelper<A, R>(
            A item,
            Func<A, R> projection)
        {
            yield return projection(item);
        }

        public static IEnumerable<R> Select<A, R>(
            this IEnumerable<A> items,
            Func<A, R> projection)
        {
            return items.SelectMany(item => SelectHelper(item, projection));
        }
    }
}

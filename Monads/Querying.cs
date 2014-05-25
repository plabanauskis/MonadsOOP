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

        // TODO: should not be public.
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

        private static IEnumerable<R> SelectHelper<A, R>(
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

        public static IEnumerable<R> Join<A, TInner, TKey, R>(
            this IEnumerable<A> outer,
            IEnumerable<TInner> inner,
            Func<A, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<A, TInner, R> resultSelector
            )
        {
            return outer.SelectMany(o =>
                {
                    var matchedInners = inner.Where(i => innerKeySelector(i).Equals(outerKeySelector(o)));

                    return matchedInners.Select(i => resultSelector(o, i));
                });
        }
    }
}

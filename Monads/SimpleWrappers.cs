using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monads
{
    public static class SimpleWrappers
    {
        public static Nullable<T> CreateSimpleNullable<T>(T item)
            where T : struct
        {
            return new Nullable<T>(item);
        }

        public static Function.OnDemand<T> CreateSimpleOnDemand<T>(T item)
        {
            return () => item;
        }

        public static IEnumerable<T> CreateSimpleSequence<T>(T item)
        {
            yield return item;
        }

        public static Lazy<T> CreateSimpleLazy<T>(T item)
        {
            return new Lazy<T>(() => item);
        }

        public static Task<T> CreateSimpleTask<T>(T item)
        {
            return Task<T>.Factory.StartNew(() => item);
        }
    }
}

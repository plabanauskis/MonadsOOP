using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monads
{
    public static class MonadicSpecialApplication
    {
        public static Nullable<R> ApplySpecialFunction<A, R>(
            Nullable<A> nullable,
            Func<A, Nullable<R>> function)
            where A : struct
            where R : struct
        {
            if (nullable.HasValue)
            {
                A unwrapped = nullable.Value;
                Nullable<R> result = function(unwrapped);
                return result;
            }
            else
            {
                return new Nullable<R>();
            }
        }

        public static Monads.Function.OnDemand<R> ApplySpecialFunction<A, R>(
            Monads.Function.OnDemand<A> onDemand,
            Func<A, Monads.Function.OnDemand<R>> function)
        {
            return () =>
                {
                    A unwrapped = onDemand();
                    Monads.Function.OnDemand<R> result = function(unwrapped);
                    return result();
                };
        }

        public static Lazy<R> ApplyFunction<A, R>(
            Lazy<A> lazy,
            Func<A, Lazy<R>> function)
        {
            return new Lazy<R>(() =>
            {
                A unwrapped = lazy.Value;
                Lazy<R> result = function(unwrapped);
                return result.Value;
            });
        }

        public static async Task<R> ApplySpecialFunction<A, R>(
            Task<A> task,
            Func<A, Task<R>> function)
        {
            A unwrapped = await task;
            Task<R> result = function(unwrapped);
            return await result;
        }

        public static IEnumerable<R> ApplySpecialFunction<A, R>(
            IEnumerable<A> sequence,
            Func<A, IEnumerable<R>> function)
        {
            foreach (A unwrapped in sequence)
            {
                IEnumerable<R> result = function(unwrapped);
                foreach (R r in result)
                {
                    yield return r;
                }
            }
        }
    }
}

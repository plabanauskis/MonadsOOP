using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monads
{
    public static class MonadicApplication
    {
        static Nullable<R> ApplyFunction<A, R>(
            Nullable<A> nullable,
            Func<A, R> function)
            where A : struct
            where R : struct
        {
            if (nullable.HasValue)
            {
                A unwrapped = nullable.Value;
                R result = function(unwrapped);
                return new Nullable<R>(result);
            }
            else
            {
                return new Nullable<R>();
            }
        }

        static Lazy<R> ApplyFunction<A, R>(
            Lazy<A> lazy,
            Func<A, R> function)
        {
            return new Lazy<R>(() =>
            {
                A unwrapped = lazy.Value;
                R result = function(unwrapped);
                return result;
            });
        }

        static Monads.Function.OnDemand<R> ApplyFunction<A, R>(
            Monads.Function.OnDemand<A> onDemand,
            Func<A, R> function)
        {
            return () =>
            {
                A unwrapped = onDemand();
                R result = function(unwrapped);
                return result;
            };
        }

        static async Task<R> ApplyFunction<A, R>(
            Task<A> task,
            Func<A, R> function)
        {
            A unwrapped = await task;
            R result = function(unwrapped);
            return result;
        }

        static IEnumerable<R> ApplyFunction<A, R>(
            IEnumerable<A> sequence,
            Func<A, R> function)
        {
            foreach (A unwrapped in sequence)
            {
                R result = function(unwrapped);
                yield return result;
            }
        }
    }
}

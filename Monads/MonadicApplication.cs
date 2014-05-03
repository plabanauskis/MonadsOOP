using System;

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
    }
}

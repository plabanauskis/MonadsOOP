using System;

namespace Monads
{
    public static class SimpleApplication
    {
        static Nullable<T> ApplyFunction<T>(
            Nullable<T> nullable,
            Func<T, T> function)
            where T : struct
        {
            if (nullable.HasValue)
            {
                T unwrapped = nullable.Value;
                T result = function(unwrapped);
                return new Nullable<T>(result);
            }
            else
            {
                return new Nullable<T>();
            }
        }
    }
}

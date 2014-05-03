using System;

namespace Monads
{
    public static class SimpleApplicationForInt32
    {
        public static Nullable<int> ApplyFunction(
            Nullable<int> nullable,
            Func<int, int> function)
        {
            if (nullable.HasValue)
            {
                int unwrapped = nullable.Value;
                int result = function(unwrapped);
                return new Nullable<int>(result);
            }
            else
            {
                return new Nullable<int>();
            }
        }
    }
}

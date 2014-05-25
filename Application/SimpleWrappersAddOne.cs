using Monads;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    static class SimpleWrappersAddOne
    {
        static Nullable<int> AddOne(Nullable<int> nullable)
        {
            if (nullable.HasValue)
            {
                int unwrapped = nullable.Value;
                int result = unwrapped + 1;
                return SimpleWrappers.CreateSimpleNullable(result);
            }
            else
            {
                return new Nullable<int>();
            }
        }

        static Function.OnDemand<int> AddOne(Function.OnDemand<int> onDemand)
        {
            return () =>
                {
                    int unwrapped = onDemand();
                    int result = unwrapped + 1;
                    return result;
                };
        }

        static Lazy<int> AddOne(Lazy<int> lazy)
        {
            return new Lazy<int>(() =>
            {
                int unwrapped = lazy.Value;
                int result = unwrapped + 1;
                return result;
            });
        }

        async static Task<int> AddOne(Task<int> task)
        {
            int unwrapped = await task;
            int result = unwrapped + 1;
            return result;
        }

        static IEnumerable<int> AddOne(IEnumerable<int> sequence)
        {
            foreach (int unwrapped in sequence)
            {
                int result = unwrapped + 1;
                yield return result;
            }
        }
    }
}

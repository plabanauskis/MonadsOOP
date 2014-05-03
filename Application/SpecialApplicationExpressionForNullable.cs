using Monads;
using System;

namespace Application
{
    static class SpecialApplicationExpressionForNullable
    {
        static Nullable<T> CreateSimpleNullable<T>(T value)
            where T : struct
        {
            return new Nullable<T>(value);
        }

        static Nullable<R> ApplySpecialFunction<A, R>(
            Nullable<A> nullable,
            Func<A, R> function)
            where A : struct
            where R : struct
        {
            return MonadicApplication.ApplyFunction<A, R>(nullable, (unwrapped) => CreateSimpleNullable<R>(function(unwrapped)));
        }
    }
}

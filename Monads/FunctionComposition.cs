using System;

namespace Monads
{
    public static class FunctionComposition
    {
        public static Func<X, Z> Compose<X, Y, Z>(
            Func<X, Y> f,
            Func<Y, Z> g)
        {
            return x => g(f(x));
        }

        public static Func<X, Nullable<Z>> ComposeSpecial<X, Y, Z>(
            Func<X, Nullable<Y>> f,
            Func<Y, Nullable<Z>> g)
            where Y : struct
            where Z : struct
        {
            return x => MonadicSpecialApplication.ApplySpecialFunction(f(x), g);
        }
    }
}

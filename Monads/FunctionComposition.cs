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
    }
}

using System;

namespace Monads
{
    public struct Tainted<T>
    {
        public T Value { get; private set; }
        public bool IsTainted { get; private set; }

        private Tainted(T value, bool isTainted)
            : this()
        {
            this.Value = value;
            this.IsTainted = isTainted;
        }

        public static Tainted<T> MakeTainted(T value)
        {
            return new Tainted<T>(value, true);
        }

        public static Tainted<T> MakeClean(T value)
        {
            return new Tainted<T>(value, false);
        }

        public static Tainted<R> Bind<A, R>(
            Tainted<A> tainted,
            Func<A, Tainted<R>> function)
        {
            Tainted<R> result = function(tainted.Value);
            if (tainted.IsTainted && !result.IsTainted)
                return new Tainted<R>(result.Value, true);
            else
                return result;
        }
    }
}

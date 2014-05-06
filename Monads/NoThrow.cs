using System;

namespace Monads
{
    public struct NoThrow<T>
    {
        private T value;
        public T Value
        {
            get
            {
                if (this.Exception != null)
                    throw this.Exception;
                else
                    return this.value;
            }
        }
        public Exception Exception { get; private set; }
        private NoThrow(T value, Exception exception)
            : this()
        {
            this.value = value;
            this.Exception = exception;
        }

        public NoThrow(T value) : this(value, null) { }

        public static NoThrow<R> Bind<A, R>(
            NoThrow<A> noThrow,
            Func<A, NoThrow<R>> function)
        {
            if (noThrow.Exception != null)
            {
                return new NoThrow<R>(default(R), noThrow.Exception);
            }

            try
            {
                return function(noThrow.Value);
            }
            catch (Exception ex)
            {
                return new NoThrow<R>(default(R), ex);
            }
        }
    }
}

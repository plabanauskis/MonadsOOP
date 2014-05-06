using System;

namespace Monads
{
    public struct Logged<T>
    {
        public T Value { get; private set; }
        public string Log { get; private set; }

        public Logged(T value, string log)
            : this()
        {
            this.Value = value;
            this.Log = log;
        }

        public Logged(T value) : this(value, null) { }

        public Logged<T> AddLog(string newLog)
        {
            return new Logged<T>(this.Value, this.Log + newLog);
        }

        public static Logged<R> Bind<A, R>(
            Logged<A> logged,
            Func<A, Logged<R>> function)
        {
            Logged<R> result = function(logged.Value);
            return new Logged<R>(result.Value, logged.Log + result.Log);
        }
    }
}

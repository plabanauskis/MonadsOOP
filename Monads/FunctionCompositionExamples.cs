using System;

namespace Monads
{
    public static class FunctionCompositionExamples
    {
        public static long Cube(int x)
        {
            return (long)x * x * x;
        }

        public static double Halve(long y)
        {
            return y / 2.0;
        }

        public static double HalveTheCube(int x)
        {
            return Halve(Cube(x));
        }

        public static Func<int, long> cube = x => (long)x * x * x;
        public static Func<long, double> halve = y => y / 2.0;
        public static Func<int, double> both = z => halve(cube(z));

        public static Func<int, double> both2 = FunctionComposition.Compose(cube, halve);

        public static Func<int, Nullable<double>> log = x => x > 0 ?
            new Nullable<double>(Math.Log(x)) : new Nullable<double>();
        public static Func<double, Nullable<decimal>> toDecimal = y => (decimal)Math.Abs(y) < decimal.MaxValue ?
            new Nullable<decimal>((decimal)y) : new Nullable<decimal>();
        public static Func<int, Nullable<decimal>> both3 = FunctionComposition.ComposeSpecial(log, toDecimal);
    }
}

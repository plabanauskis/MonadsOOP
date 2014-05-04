using System;

namespace Monads
{
    public static class SimpleFunctionComposition
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
    }
}

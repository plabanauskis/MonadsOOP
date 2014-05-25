using System;

namespace Application
{
    static class SimpleApplicationForInt32
    {
        static Nullable<int> AddOne(Nullable<int> nullable)
        {
            return Monads.SimpleApplicationForInt32.ApplyFunction(nullable, x => x + 1);
        }
    }
}

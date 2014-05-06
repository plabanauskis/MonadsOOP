using Monads;
using System;
using System.Collections.Generic;

namespace Application
{
    static class QueryExample
    {
        private static IEnumerable<int> original = new List<int> { 1, 2, 3 };

        static IEnumerable<int> Odd(int i)
        {
            if (i % 2 == 0)
                yield return i;
        }

        static void SelectManyExample()
        {
            IEnumerable<int> query = original.SelectMany(Odd);
        }

        static Func<int, IEnumerable<int>> odd = num => Querying.WhereHelper(
            num,
            item => item % 2 != 0);

        static void SelectManyExampleGeneral()
        {
            IEnumerable<int> original = new List<int> { 1, 2, 3 };
            IEnumerable<int> query = original.SelectMany(odd);
        }

        static void WhereExample()
        {
            IEnumerable<int> query = original.Where(num => num % 2 != 0);
        }

        static void SelectExample()
        {
            IEnumerable<int> query = original.Select(num => num + 100);
        }
    }
}

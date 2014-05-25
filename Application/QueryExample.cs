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

        #region Join example code for testing the implementation (borrowed from http://msdn.microsoft.com/en-us/library/bb534675%28v=vs.110%29.aspx)
        class Person
        {
            public string Name { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        static void JoinExample()
        {
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            var query = people.Join(pets,
                                person => person,
                                pet => pet.Owner,
                                (person, pet) => new { OwnerName = person.Name, Pet = pet.Name });


            foreach (var obj in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.OwnerName,
                    obj.Pet);
            }
        }
        #endregion
    }
}

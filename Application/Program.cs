using Monads.Maybe;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(1.Unit().QuerySyntax());
            System.Console.WriteLine(1000.Unit().QuerySyntax());
            System.Console.WriteLine(Maybe<int>.Null.QuerySyntax());
        }
    }
}

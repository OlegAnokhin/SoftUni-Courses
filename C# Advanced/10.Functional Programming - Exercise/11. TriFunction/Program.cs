using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // най-доброто решение
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Console.WriteLine(names
                .First(name => name.Select(symbol => (int)symbol).Sum() >= n));
        }
    }
}

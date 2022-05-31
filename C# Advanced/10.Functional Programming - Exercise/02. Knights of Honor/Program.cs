using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ").ToList();

            Action<string> printNames = name => Console.WriteLine($"Sir {name}");
            list.ForEach(printNames);
        }
    }
}

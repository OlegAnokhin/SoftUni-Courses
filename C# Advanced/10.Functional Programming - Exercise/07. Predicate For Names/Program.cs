using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthName = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string name in names)
            {
                if (name.Length <= lengthName)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}

//{
//    int n = int.Parse(Console.ReadLine());
//    Predicate<string> cond = str => str.Length <= n;
//    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
//    .ToList().FindAll(cond).ForEach(Console.WriteLine);
//}
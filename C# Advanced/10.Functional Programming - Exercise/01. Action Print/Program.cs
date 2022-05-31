using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ").ToList();

            Action<string> printNames = name => Console.WriteLine(name);
            list.ForEach(printNames);
        }
    }
}

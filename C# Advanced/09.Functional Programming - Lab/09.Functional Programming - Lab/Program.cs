using System;
using System.Linq;

namespace _09.Functional_Programming___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split(" ").Select(int.Parse).Max());


        }
    }
}

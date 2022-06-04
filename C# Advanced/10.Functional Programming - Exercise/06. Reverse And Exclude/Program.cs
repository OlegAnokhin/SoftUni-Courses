using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            List<int> addNumbers = new List<int>();
            int num = int.Parse(Console.ReadLine());

            foreach (int i in numbers)
            {
                if (i % num != 0)
                {
                    addNumbers.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", addNumbers));
        }
    }
}

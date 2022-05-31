using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> numbers = new List<int>();
            for (int number = 1; number <= n; number++)
            {
                numbers.Add(number);
            }
            List<int> printNumbers = new List<int>();

            foreach (int number in numbers)
            {
                bool isDivisible = true;
                foreach (int divider in dividers)
                {
                    Predicate<int> divisible = number => number % divider == 0;
                    if (!divisible(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    printNumbers.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", printNumbers));
        }
    }
}

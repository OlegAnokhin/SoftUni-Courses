using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startNumber = int.Parse(input.Split()[0]);
            int endNumber = int.Parse(input.Split()[1]);
            List<int> numbers = new List<int>();
            for (int number = startNumber; number <= endNumber; number++)
            {
                numbers.Add(number);
            }
            Predicate<int> predicate = null;

            string type = Console.ReadLine();
            if (type == "even")
            {
                predicate = number => number % 2 == 0;
            }
            else if (type == "odd")
            {
                predicate = number => number % 2 != 0;
            }
            Console.WriteLine(string.Join(" ", numbers.FindAll(predicate)));
        }
    }
}
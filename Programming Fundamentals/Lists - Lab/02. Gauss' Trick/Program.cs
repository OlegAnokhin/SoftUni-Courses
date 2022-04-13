using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> condensedList = new List<int>();

            for (int i = 0; i < number.Count / 2; i++)
            {
                int newElement = number[i] + number[number.Count - 1 - i];
                condensedList.Add(newElement);
            }
            if (number.Count % 2 != 0)
            {
                condensedList.Add(number[number.Count / 2]);
            }
            Console.WriteLine(string.Join(" ", condensedList));
        }
    }
}

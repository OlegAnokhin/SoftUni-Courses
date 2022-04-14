using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<double> numbers = Console.ReadLine()
            //    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            //    .Select(double.Parse)
            //    .ToList();
                
            //SortedDictionary<double, int> occurencies = new SortedDictionary<double, int>();
            //foreach (var number in numbers)
            //{
            //    if (occurencies.ContainsKey(number))
            //    {
            //        occurencies[number] += 1;
            //    }
            //    else
            //    {
            //        occurencies.Add(number, 1);
            //    }
            //}
            //foreach (var item in occurencies)
            //{
            //    Console.WriteLine($"{item.Key} -> {item.Value}");
            //}

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts.Add(number, 1);
                }
            }
            foreach (var number in counts)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}

﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countByNum = new Dictionary<double, int>();
            var nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (var num in nums)
            {
                if (countByNum.ContainsKey(num))
                {
                    countByNum[num]++;
                }
                else
                {
                    countByNum[num] = 1;
                }
            }
            foreach (var pair in countByNum)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}

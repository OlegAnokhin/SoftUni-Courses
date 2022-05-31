using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Func<string, int> Parse = (str) => int.Parse(str);
            //string input = Console.ReadLine();
            //int[] nums = input.Split(" ").Select(Parse).ToArray();
            //Console.WriteLine(nums.Min());

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<List<int>, int> getMinEl = numbers => numbers.Min();
            Console.WriteLine(getMinEl(numbers));
        }
    }
}


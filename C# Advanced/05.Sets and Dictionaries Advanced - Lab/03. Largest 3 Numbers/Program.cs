using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse)
                .OrderByDescending(x => x).ToList().Take(3);

            Console.WriteLine(string.Join(" ", nums));

            // bez Take(3);
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i < nums.Count)
            //    {
            //        Console.WriteLine(nums[i] + " ");
            //    }
            //}
        }
    }
}

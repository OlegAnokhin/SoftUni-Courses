using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static int Parse(string str) => int.Parse(str);
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] nums = input.Split(", ").Select(Parse).ToArray();
            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());

            //string input = Console.ReadLine();
            //Func<string, int> func = x => int.Parse(x);
            //int[] numbers = input.Split(new string[] {", "}, 
            //    StringSplitOptions.RemoveEmptyEntries)
            //    .Select(func).ToArray();
            //Console.WriteLine(numbers.Length);
            //Console.WriteLine(numbers.Sum());
        }
    }
}

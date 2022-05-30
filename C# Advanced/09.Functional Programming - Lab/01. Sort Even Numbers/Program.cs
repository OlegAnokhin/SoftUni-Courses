using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = Console.ReadLine()
            //    .Split(new string[] {", "},
            //    StringSplitOptions.RemoveEmptyEntries)
            //    .Select(n = > int.Parse(n))
            //    .Where(x => x % 2 == 0)
            //    .OrderBy(n => n)
            //    .ToArray();
            //string result = string.Join(", ", numbers);
            //Console.WriteLine(result);

            Func<string, int> parse = x =>int.Parse(x);
            Func<int, bool> filter = x => x % 2 == 0;
            Func<int, int> identity = n => n;

            string input = Console.ReadLine();
            string[] token = input.Split(", ");
            int[] nums = token.Select(parse).ToArray();
            int[] evenNums = nums.Where(filter).ToArray();
            int[] orderedEvenNums = evenNums.OrderBy(identity).ToArray();
            Console.WriteLine(string.Join(", ", orderedEvenNums));
        }
    }
}

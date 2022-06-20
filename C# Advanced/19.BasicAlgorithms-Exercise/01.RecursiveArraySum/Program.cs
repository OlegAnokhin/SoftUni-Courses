using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            long sum = SumArray(array, 0);
            Console.WriteLine(sum);
        }
        private static long SumArray(int[] array, int startIndex)
        {
            if (startIndex == array.Length - 1)
            {
                return array[startIndex];
            }
            return array[startIndex] + SumArray(array, startIndex + 1);
        }
    }
}

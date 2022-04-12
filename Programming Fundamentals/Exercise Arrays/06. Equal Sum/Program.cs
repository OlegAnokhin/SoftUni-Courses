using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isFound = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                for (int a = 0; a < i; a++)
                {
                    leftSum += arr[a];
                }

                int rightSum = 0;
                for (int b = arr.Length -1; b > i; b--)
                {
                    rightSum += arr[b];
                }
                if (leftSum == rightSum && !isFound)
                {
                    Console.WriteLine(i);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}

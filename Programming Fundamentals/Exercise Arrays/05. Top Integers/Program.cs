using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] topInteger = new int[arr.Length];

            int topIntegersIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNum = arr[i];
                bool itTopInteger = true;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int nextNum = arr[j];
                    if (currentNum <= nextNum)
                    {
                        itTopInteger = false;
                        break;
                    }
                }
                if (itTopInteger)
                {
                    topInteger[topIntegersIndex] = currentNum; 
                    topIntegersIndex++;
                }
            }
            for (int i = 0; i < topIntegersIndex; i++)
            {
            Console.Write($"{topInteger[i]} ");
            }
        }
    }
}

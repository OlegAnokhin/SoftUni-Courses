using System;
using System.Linq;

namespace _03_Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int row = 1; row <= n; row++)
            {
                int[] currentRowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                int firstNum = currentRowData[0];
                int secondNum = currentRowData[1];

                if (row % 2 != 0)
                {
                    firstArr[row - 1] = firstNum;
                    secondArr[row - 1] = secondNum;
                }
                else
                {
                    firstArr[row - 1] = secondNum;
                    secondArr[row - 1] = firstNum;
                }
            }
            Console.WriteLine(String.Join(" ",firstArr));
            Console.WriteLine(String.Join(" ",secondArr));

        }
    }
}

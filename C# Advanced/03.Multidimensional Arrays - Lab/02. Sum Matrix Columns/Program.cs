using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            (int rowsCount, int colsCount) = (dimension[0], dimension[1]);

            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] line = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            long [] colSums = new long[colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    colSums[col] += matrix[row, col];
                }
            }
            for (int col = 0; col < colsCount; col++)
            {
                Console.WriteLine(colSums[col]);
            }
        }
    }
}

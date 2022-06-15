using System;
using System.Linq;

namespace _02.BeaverAtWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            (int rows, int cols) = FindBeaberLocation(matrix);
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                else if (command == "up")
                {
                    Move(matrix, rows, cols, rows - 1, cols);
                }
                else if (command == "down")
                {
                    Move(matrix, rows, cols, rows + 1, cols);
                }
                else if (command == "left")
                {
                    Move(matrix, rows, cols, rows, cols - 1);
                }
                else if (command == "right")
                {
                    Move(matrix, rows, cols, rows, cols + 1);
                }
                else
                {
                    throw new Exception("Invalid command: " + command);
                }
            }
        }

        private static char[,] ReadMatrix(int n)
        {
            var matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] rowChars = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowChars[col][0];
                }
            }
            return matrix;
        }

        private static (int x, int y) FindBeaberLocation(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }
            throw new Exception("Beaver not found in the matrix!");
        }
        private static void Move(char[,] matrix, int row, int col, int newRow, int newCol)
        {
            matrix[row, col] = '-';
            matrix[newRow, newCol] = 'B';
        }
    }
}

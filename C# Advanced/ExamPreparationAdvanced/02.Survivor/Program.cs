using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            MatrixFilling(matrix);
            var collectedTokens = CollectedTokens(matrix, out int opponentTokens);
            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        public static void MatrixFilling(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().Replace(" ", "").ToCharArray();
                matrix[row] = chars;
            }
        }
        public static int CollectedTokens(char[][] matrix, out int opponentTokens)
        {
            string command;
            int collectedTokens = 0;
            opponentTokens = 0;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs.Length == 3)
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    if (isValidIndex(row, col, matrix))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                }
                else
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    string direction = cmdArgs[3];
                    if (isValidIndex(row, col, matrix))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col] = '-';
                        }
                        switch (direction)
                        {
                            case "up":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int moves = row - i;
                                    if (isValidIndex(moves, col, matrix))
                                    {
                                        if (matrix[moves][col] == 'T')
                                        {
                                            opponentTokens++;
                                            matrix[moves][col] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "down":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int moves = row + i;
                                    if (isValidIndex(moves, col, matrix))
                                    {
                                        if (matrix[moves][col] == 'T')
                                        {
                                            opponentTokens++;
                                            matrix[moves][col] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int moves = col - i;
                                    if (isValidIndex(row, moves, matrix))
                                    {
                                        if (matrix[row][moves] == 'T')
                                        {
                                            opponentTokens++;
                                            matrix[row][moves] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "right":
                                for (int i = 1; i <= 3; i++)
                                {
                                    int moves = col + i;
                                    if (isValidIndex(row, moves, matrix))
                                    {
                                        if (matrix[row][moves] == 'T')
                                        {
                                            opponentTokens++;
                                            matrix[row][moves] = '-';
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return collectedTokens;
        }
        public static bool isValidIndex(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && 
                   col >= 0 && col < matrix[row].Length;
        }
        public static void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                var currLine = string.Join(' ', line);
                Console.WriteLine(currLine);
            }
        }
    }
}
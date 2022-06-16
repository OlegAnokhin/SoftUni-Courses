using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];


            for (int row = 0; row <= size - 1; row++)
            {
                char[] currRowElement = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();

                for (int col = 0; col < currRowElement.Length; col++)
                {
                    matrix[row, col] = currRowElement[col];
                }
            }
            int countBlack = 0;
            int countWhite = 0;
            int countSummer = 0;
            int eaten = 0;

            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string commandName = command.Split()[0];
                int row = int.Parse(command.Split()[1]);
                int col = int.Parse(command.Split()[2]);

                if (commandName == "Collect")
                {
                    char truffel = matrix[row, col];
                    matrix[row, col] = '-';
                    if (truffel == 'B')
                    {
                        countBlack++;
                    }
                    else if (truffel == 'W')
                    {
                        countWhite++;
                    }
                    else if (truffel == 'S')
                    {
                        countSummer++;
                    }
                }
                else if (commandName == "Wild_Boar")
                {
                    string direction = command.Split()[3];
                    switch (direction)
                    {
                        case "up":
                            while (IsValidRow(row, size))
                            {
                                if (EatBoar(row, col, matrix))
                                {
                                    eaten++;
                                }
                                row -= 2;
                            }
                            break;
                        case "down":
                            while (IsValidRow(row, size))
                            {
                                if (EatBoar(row, col, matrix))
                                {
                                    eaten++;
                                }
                                row += 2;
                            }
                            break;
                        case "left":
                            while (IsValidCol(col, size))
                            {
                                if (EatBoar(row, col, matrix))
                                {
                                    eaten++;
                                }
                                col -= 2;
                            }
                            break;
                        case "right":
                            while (IsValidCol(col, size))
                            {
                                if (EatBoar(row, col, matrix))
                                {
                                    eaten++;
                                }
                                col += 2;
                            }
                            break;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {countBlack} black, " +
                $"{countSummer} summer, and {countWhite} " +
                $"white truffles.");
            Console.WriteLine($"The wild boar has eaten {eaten} truffles.");
            PrintMatrix(matrix);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static bool EatBoar(int row, int col, char[,] matrix)
        {
            char currSymbol = matrix[row, col];
            if (currSymbol == 'S' || currSymbol == 'B' || currSymbol == 'W')
            {
                matrix[row, col] = '-';
                return true;
            }
            return false;
        }

        public static bool IsValidRow(int row, int size)
        {
            return row >= 0 && row < size;
        }
        public static bool IsValidCol(int col, int size)
        {
            return col >= 0 && col < size;
        }
    }
}
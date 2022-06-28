using System;
using System.Linq;

namespace _02.WallDestroyerEXAM25._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int vankoRow = default;
            int vankoCol = default;
            int holsCount = 1;
            int rodHitCount = 0;

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                matrix[i] = currentRow;
                if (currentRow.Contains('V'))
                {
                    vankoRow = i;
                    vankoCol = currentRow.ToList().IndexOf('V');
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "up" && vankoRow - 1 >= 0)
                {
                    matrix[vankoRow][vankoCol] = '*';
                    vankoRow--;
                    if (matrix[vankoRow][vankoCol] == '-')
                    {
                        matrix[vankoRow][vankoCol] = '*';
                        holsCount++;
                    }
                    else if (matrix[vankoRow][vankoCol] == 'R')
                    {
                        vankoRow++;
                        rodHitCount++;
                   //     holsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow][vankoCol] == 'C')
                    {
                        holsCount++;
                        matrix[vankoRow][vankoCol] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holsCount} hole(s).");
                        break;
                    }
                    else if (matrix[vankoRow][vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "down" && vankoRow + 1 < rows)
                {
                    matrix[vankoRow][vankoCol] = '*';
                    vankoRow++;
                    if (matrix[vankoRow][vankoCol] == '-')
                    {
                        matrix[vankoRow][vankoCol] = '*';
                        holsCount++;
                    }
                    else if (matrix[vankoRow][vankoCol] == 'R')
                    {
                        vankoRow--;
                        rodHitCount++;
                  //      holsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow][vankoCol] == 'C')
                    {
                        holsCount++;
                        matrix[vankoRow][vankoCol] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holsCount} hole(s).");
                        break;
                    }
                    else if (matrix[vankoRow][vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "left" && vankoCol - 1 >= 0)
                {
                    matrix[vankoRow][vankoCol] = '*';
                    vankoCol--;
                    if (matrix[vankoRow][vankoCol] == '-')
                    {
                        matrix[vankoRow][vankoCol] = '*';
                        holsCount++;
                    }
                    else if (matrix[vankoRow][vankoCol] == 'R')
                    {
                        vankoCol++;
                        rodHitCount++;
                  //      holsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow][vankoCol] == 'C')
                    {
                        holsCount++;
                        matrix[vankoRow][vankoCol] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holsCount} hole(s).");
                        break;
                    }
                    else if (matrix[vankoRow][vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                else if (command == "right" && vankoCol + 1 < matrix[0].Length)
                {
                    matrix[vankoRow][vankoCol] = '*';
                    vankoCol++;
                    if (matrix[vankoRow][vankoCol] == '-')
                    {
                        matrix[vankoRow][vankoCol] = '*';
                        holsCount++;
                    }
                    else if (matrix[vankoRow][vankoCol] == 'R')
                    {
                        vankoCol--;
                        rodHitCount++;
              //          holsCount++;
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (matrix[vankoRow][vankoCol] == 'C')
                    {
                        holsCount++;
                        matrix[vankoRow][vankoCol] = 'E';
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holsCount} hole(s).");
                        break;
                    }
                    else if (matrix[vankoRow][vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    }
                }
                matrix[vankoRow][vankoCol] = 'V';
                command = Console.ReadLine();
            }
            if (command == "End")
            {
                Console.WriteLine($"Vanko managed to make {holsCount} hole(s) and he hit only {rodHitCount} rod(s).");
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(new String(matrix[i]));
            }
        }
    }
}
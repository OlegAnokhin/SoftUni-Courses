
using System;
using System.Collections.Generic;

namespace _02.BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            List<string> woodCollection = new List<string>();
            int beaverRow = 0;
            int beaverCol = 0;
            int woods = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = colElements[cols];
                    if (matrix[rows, cols] == "B")
                    {
                        beaverRow = rows;
                        beaverCol = cols;
                    }
                    if (matrix[rows, cols] != "B" && matrix[rows, cols] != "F" && matrix[rows, cols] != "-")
                    {
                        woods++;
                    }
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                matrix[beaverRow, beaverCol] = "-";
                if (command == "end")
                {
                    matrix[beaverRow, beaverCol] = "B";
                    break;
                }
                else if (command == "up")
                {
                    beaverRow--;
                    if (beaverRow >= 0)
                    {
                        if (matrix[beaverRow, beaverCol] == "F")
                        {
                            matrix[beaverRow, beaverCol] = "-";
                            beaverRow = n - 1;
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverRow = 0;
                            }
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverRow = n - 1;
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == "-")
                        {
                            continue;
                        }
                        else
                        {
                            woodCollection.Add(matrix[beaverRow, beaverCol]);
                            woods--;
                        }
                    }
                    else
                    {
                        woodCollection.RemoveAt(woodCollection.Count - 1);
                        beaverRow++;
                    }
                }
                else if (command == "down")
                {
                    beaverRow++;
                    if (beaverRow < n)
                    {
                        if (matrix[beaverRow, beaverCol] == "F")
                        {
                            matrix[beaverRow, beaverCol] = "-";
                            beaverRow = 0;
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverRow = n - 1;
                            }
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverRow = 0;
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == "-")
                        {
                            continue;
                        }
                        else
                        {
                            woodCollection.Add(matrix[beaverRow, beaverCol]);
                            woods--;
                        }
                    }
                    else
                    {
                        woodCollection.RemoveAt(woodCollection.Count - 1);
                        beaverRow--;
                    }
                }
                else if (command == "right")
                {
                    beaverCol++;
                    if (beaverCol < n)
                    {
                        if (matrix[beaverRow, beaverCol] == "F")
                        {
                            matrix[beaverRow, beaverCol] = "-";
                            beaverCol = 0;
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverCol = n - 1;
                            }
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverCol = 0;
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == "-")
                        {
                            continue;
                        }
                        else
                        {
                            woodCollection.Add(matrix[beaverRow, beaverCol]);
                            woods--;
                        }
                    }
                    else
                    {
                        woodCollection.RemoveAt(woodCollection.Count - 1);
                        beaverCol--;
                    }
                }
                else if (command == "left")
                {
                    beaverCol--;
                    if (beaverCol >= 0)
                    {
                        if (matrix[beaverRow, beaverCol] == "F")
                        {
                            matrix[beaverRow, beaverCol] = "-";
                            beaverCol = n - 1;
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverCol = 0;
                            }
                            if (matrix[beaverRow, beaverCol] == "F")
                            {
                                matrix[beaverRow, beaverCol] = "-";
                                beaverCol = n - 1;
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == "-")
                        {
                            continue;
                        }
                        else
                        {
                            woodCollection.Add(matrix[beaverRow, beaverCol]);
                            woods--;
                        }
                    }
                    else
                    {
                        woodCollection.RemoveAt(woodCollection.Count - 1);
                        beaverCol++;
                    }
                }
                if (woods == 0)
                {
                    matrix[beaverRow, beaverCol] = "B";
                    break;
                }
            }
            if (woods > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woods} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {woodCollection.Count} wood branches: {string.Join(", ", woodCollection)}.");
            }
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
//using System;
//using System.Collections.Generic;

//namespace _02.BeaverAtWork
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = int.Parse(Console.ReadLine());
//            string[,] matrix = new string[n, n];
//            List<string> woodCollection = new List<string>();
//            int beaverRow = 0;
//            int beaverCol = 0;
//            int woods = 0;
//            for (int rows = 0; rows < matrix.GetLength(0); rows++)
//            {
//                string[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
//                for (int cols = 0; cols < matrix.GetLength(1); cols++)
//                {
//                    matrix[rows, cols] = colElements[cols];
//                    if (matrix[rows, cols] == "B")
//                    {
//                        beaverRow = rows;
//                        beaverCol = cols;
//                    }
//                    if (matrix[rows, cols] != "B" && matrix[rows, cols] != "F" && matrix[rows, cols] != "-")
//                    {
//                        woods++;
//                    }
//                }
//            }
//            while (true)
//            {
//                string command = Console.ReadLine();
//                matrix[beaverRow, beaverCol] = "-";
//                if (command == "end")
//                {
//                    matrix[beaverRow, beaverCol] = "B";
//                    break;
//                }
//                else if (command == "up")
//                {
//                    beaverRow--;
//                    if (beaverRow >= 0)
//                    {
//                        if (matrix[beaverRow, beaverCol] == "F")
//                        {
//                            matrix[beaverRow, beaverCol] = "-";
//                            beaverRow = n - 1;
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverRow = 0;
//                            }
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverRow = n - 1;
//                            }
//                        }
//                        else if (matrix[beaverRow, beaverCol] == "-")
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            woodCollection.Add(matrix[beaverRow, beaverCol]);
//                            woods--;
//                        }
//                    }
//                    else
//                    {
//                        woodCollection.RemoveAt(woodCollection.Count - 1);
//                        beaverRow++;
//                    }
//                }
//                else if (command == "down")
//                {
//                    beaverRow++;
//                    if (beaverRow < n)
//                    {
//                        if (matrix[beaverRow, beaverCol] == "F")
//                        {
//                            matrix[beaverRow, beaverCol] = "-";
//                            beaverRow = 0;
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverRow = n - 1;
//                            }
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverRow = 0;
//                            }
//                        }
//                        else if (matrix[beaverRow, beaverCol] == "-")
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            woodCollection.Add(matrix[beaverRow, beaverCol]);
//                            woods--;
//                        }
//                    }
//                    else
//                    {
//                        woodCollection.RemoveAt(woodCollection.Count - 1);
//                        beaverRow--;
//                    }
//                }
//                else if (command == "right")
//                {
//                    beaverCol++;
//                    if (beaverCol < n)
//                    {
//                        if (matrix[beaverRow, beaverCol] == "F")
//                        {
//                            matrix[beaverRow, beaverCol] = "-";
//                            beaverCol = 0;
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverCol = n - 1;
//                            }
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverCol = 0;
//                            }
//                        }
//                        else if (matrix[beaverRow, beaverCol] == "-")
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            woodCollection.Add(matrix[beaverRow, beaverCol]);
//                            woods--;
//                        }
//                    }
//                    else
//                    {
//                        woodCollection.RemoveAt(woodCollection.Count - 1);
//                        beaverCol--;
//                    }
//                }
//                else if (command == "left")
//                {
//                    beaverCol--;
//                    if (beaverCol >= 0)
//                    {
//                        if (matrix[beaverRow, beaverCol] == "F")
//                        {
//                            matrix[beaverRow, beaverCol] = "-";
//                            beaverCol = n - 1;
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverCol = 0;
//                            }
//                            if (matrix[beaverRow, beaverCol] == "F")
//                            {
//                                matrix[beaverRow, beaverCol] = "-";
//                                beaverCol = n - 1;
//                            }
//                        }
//                        else if (matrix[beaverRow, beaverCol] == "-")
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            woodCollection.Add(matrix[beaverRow, beaverCol]);
//                            woods--;
//                        }
//                    }
//                    else
//                    {
//                        woodCollection.RemoveAt(woodCollection.Count - 1);
//                        beaverCol++;
//                    }
//                }
//                if (woods == 0)
//                {
//                    matrix[beaverRow, beaverCol] = "B";
//                    break;
//                }
//            }
//            if (woods > 0)
//            {
//                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woods} branches left.");
//            }
//            else
//            {
//                Console.WriteLine($"The Beaver successfully collect {woodCollection.Count} wood branches: {string.Join(", ", woodCollection)}.");
//            }
//            for (int rows = 0; rows < n; rows++)
//            {
//                for (int cols = 0; cols < n; cols++)
//                {
//                    Console.Write(matrix[rows, cols] + " ");
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Beaver_at_Work
{
    public class Program
    {
        private static int beaverRow;
        private static int beaverCol;
        private static char[,] matrix;
        private static string lastDirection;

        private static List<char> branches = new List<char>();
        private static int totalBranches = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n, n];

            //Initialize Matrix and set bunny position
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];

                    if (matrix[i, j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                    }
                    else if (char.IsLower(matrix[i, j]))
                    {
                        totalBranches++;
                    }
                }
            }

            string direction = Console.ReadLine();

            while (direction != "end")
            {
                lastDirection = direction;

                if (direction == "up")
                {
                    Move(-1, 0);
                }
                else if (direction == "down")
                {
                    Move(1, 0);
                }
                else if (direction == "right")
                {
                    Move(0, 1);
                }
                else if (direction == "left")
                {
                    Move(0, -1);
                }

                if (totalBranches == 0)
                {
                    break;
                }
                direction = Console.ReadLine();
            }

            if (totalBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write((char)matrix[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col)
        {
            if (!IsInside(beaverRow + row, beaverCol + col))
            {
                if (branches.Any())
                {
                    branches.Remove(branches[branches.Count - 1]);
                }
                return;
            }
            matrix[beaverRow, beaverCol] = '-';
            beaverRow += row;
            beaverCol += col;

            if (char.IsLower(matrix[beaverRow, beaverCol]))
            {
                branches.Add(matrix[beaverRow, beaverCol]);
                matrix[beaverRow, beaverCol] = 'B';
                totalBranches--;
            }
            else if (matrix[beaverRow, beaverCol] == 'F')
            {
                matrix[beaverRow, beaverCol] = '-';

                if (lastDirection == "up")
                {
                    if (beaverRow == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Add(matrix[0, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "down")
                {
                    if (beaverRow == matrix.GetLength(0) - 1)
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Add(matrix[0, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "right")
                {
                    if (beaverCol == matrix.GetLength(1) - 1)
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Add(matrix[beaverRow, 0]);
                            totalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            totalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "left")
                {
                    if (beaverCol == 0)
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            totalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Add(matrix[beaverRow, 0]);
                            totalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
            }
            else
            {
                matrix[beaverRow, beaverCol] = 'B';
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}

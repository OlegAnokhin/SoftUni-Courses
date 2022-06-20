using System;

namespace _02.Armory
{
    public class Program
    {
        private static int armyRow;
        private static int armyCol;
        private static int firstMirrorRow;
        private static int firstMirrorCol;
        private static int secondMirrorRow;
        private static int secondMirrorCol;
        private static int mirrorCount;
        private static int swords;
        private static char[,] matrix;
        private static bool ItIsOut = false;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] += input[col];
                    if (input[col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                    if (input[col] == 'M')
                    {
                        if (mirrorCount != 0)
                        {
                            secondMirrorRow = row;
                            secondMirrorCol = col;
                        }
                        else
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                            mirrorCount++;
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            while (swords < 65)
            {
                if (command == "up")
                {
                    Move(-1, 0);
                    if (ItIsOut)
                    {
                        break;
                    }
                }
                else if (command == "down")
                {
                    Move(1, 0);
                    if (ItIsOut)
                    {
                        break;
                    }
                }
                else if (command == "right")
                {
                    Move(0, 1);
                    if (ItIsOut)
                    {
                        break;
                    }
                }
                else if (command == "left")
                {
                    Move(0, -1);
                    if (ItIsOut)
                    {
                        break;
                    }
                }
                if (swords >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {swords} gold coins.");
                    break;
                }
                command = Console.ReadLine();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static void Move(int row, int col)
        {
            if (!IsInside(armyRow + row, armyCol + col))
            {
                Console.WriteLine("I do not need more swords!");
                Console.WriteLine($"The king paid {swords} gold coins.");
                matrix[armyRow, armyCol] = '-';
                ItIsOut = true;
                return;
            }
            matrix[armyRow, armyCol] = '-';
            armyRow += row;
            armyCol += col;
            if (char.IsNumber(matrix[armyRow, armyCol]))
            {
                char currswords = matrix[armyRow, armyCol];
                int swordsCountToBuy = currswords - 48;
                swords += swordsCountToBuy;
                matrix[armyRow, armyCol] = 'A';
            }
            if (matrix[armyRow, armyCol] == 'M')
            {
                matrix[armyRow, armyCol] = '-';
                armyRow = secondMirrorRow;
                armyCol = secondMirrorCol;
                matrix[armyRow, armyCol] = 'A';
            }
        }
        public static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}

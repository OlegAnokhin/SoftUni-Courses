using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currWhiteRow = 0;
            int currWhiteCol = 0;
            int currBlackRow = 0;
            int currBlackCol = 0;

            char[,] matrix = new char[8, 8];
            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] += input[col];

                    if (input[col] == 'w')
                    {
                        currWhiteRow = row;
                        currWhiteCol = col;
                    }
                    if (input[col] == 'b')
                    {
                        currBlackRow = row;
                        currBlackCol = col;
                    }
                }
            }
            while (true)
            {
                if (IsInMatrix(currWhiteRow - 1, currWhiteCol - 1) && matrix[currWhiteRow - 1, currWhiteCol - 1] == 'b')
                {
                    string chessPosition = SetChessPosition(currWhiteRow - 1, currWhiteCol - 1);
                    Console.WriteLine($"Game over! White capture on {chessPosition}.");
                    break;

                }
                else if (IsInMatrix(currWhiteRow - 1, currWhiteCol + 1) && matrix[currWhiteRow - 1, currWhiteCol + 1] == 'b')
                {
                    string position = SetChessPosition(currWhiteRow - 1, currWhiteCol + 1);
                    Console.WriteLine($"Game over! White capture on {position}.");
                    break;
                }
                else
                {
                    matrix[currWhiteRow, currWhiteCol] = '-';
                    currWhiteRow --;
                    matrix[currWhiteRow, currWhiteCol] = 'w';
                    if (currWhiteRow == 0)
                    {
                        string position = SetChessPosition(currWhiteRow, currWhiteCol);
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {position}.");
                        break;
                    }
                }
                if (IsInMatrix(currBlackRow + 1, currBlackCol - 1) && matrix[currBlackRow + 1, currBlackCol - 1] == 'w')
                {
                    string position = SetChessPosition(currBlackRow + 1, currBlackCol - 1);
                    Console.WriteLine($"Game over! Black capture on {position}.");
                    break;
                }
                else if (IsInMatrix(currBlackRow + 1, currBlackCol + 1) && matrix[currBlackRow + 1, currBlackCol + 1] == 'w')
                {
                    string position = SetChessPosition(currBlackRow + 1, currBlackCol + 1);
                    Console.WriteLine($"Game over! Black capture on {position}.");
                    break;
                }
                else
                {
                    matrix[currBlackRow, currBlackCol] = '-';
                    currBlackRow ++;
                    matrix[currBlackRow, currBlackCol] = 'b';
                    if (currBlackRow == 7)
                    {
                        string position = SetChessPosition(currBlackRow, currBlackCol);
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {position}.");
                        break;
                    }
                }
            }
        }
        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row <= 7 && col >= 0 && col <= 7;
        }
        private static string SetChessPosition(int row, int col)
        {
            var sb = new StringBuilder();
            for (int i = 8; i >= 0; i--)
            {
                if (col == i)
                {
                    sb.Append((char)(i + 97));
                    break;
                }
            }
            int counter = 8;
            for (int i = 0; i < 8; i++)
            {
                if (row == i)
                {
                    sb.Append(counter);
                    break;
                }
                counter--;
            }
            return $"{sb}";
        }
    }
}
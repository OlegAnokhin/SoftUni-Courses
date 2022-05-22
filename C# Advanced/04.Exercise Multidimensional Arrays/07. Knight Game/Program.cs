//using System;
//using System.Collections.Generic;



//namespace _07._Knight_Game
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Queue<Tuple<int, int>> kniteMoves = new Queue<Tuple<int, int>>();
//            kniteMoves.Enqueue(new Tuple<int, int>(-1, -2));
//            kniteMoves.Enqueue(new Tuple<int, int>(+1, -2));
//            kniteMoves.Enqueue(new Tuple<int, int>(-2, -1));
//            kniteMoves.Enqueue(new Tuple<int, int>(+2, -1));
//            kniteMoves.Enqueue(new Tuple<int, int>(-2, +1));
//            kniteMoves.Enqueue(new Tuple<int, int>(+2, +1));
//            kniteMoves.Enqueue(new Tuple<int, int>(-1, +2));
//            kniteMoves.Enqueue(new Tuple<int, int>(+1, +2));
//            int boardSize = int.Parse(Console.ReadLine());
//            string[,] board = new string[boardSize, boardSize];
//            for (int i = 0; i < boardSize; i++)
//            {
//                char[] curRow = Console.ReadLine().ToCharArray();
//                for (int k = 0; k < boardSize; k++)
//                {
//                    board[i, k] = curRow[k].ToString();
//                }
//            }
//            bool foundHit = true;
//            int mostHits = 0;
//            int saveMostHits = 0;
//            int bestRow = int.MinValue;
//            int bestCol = int.MinValue;
//            int removedResult = 0;
//            while (foundHit == true)
//            {
//                for (int i = 0; i < board.GetLength(0); i++)
//                {
//                    for (int k = 0; k < board.GetLength(1); k++)
//                    {
//                        if (board[i, k] == "K")
//                        {
//                            for (int j = 1; j <= kniteMoves.Count; j++)
//                            {
//                                int row = kniteMoves.Peek().Item1;
//                                int col = kniteMoves.Peek().Item2;
//                                kniteMoves.Enqueue(kniteMoves.Dequeue());
//                                try
//                                {
//                                    if (board[i + row, k + col] == "K")
//                                    {
//                                        mostHits++;
//                                    }
//                                }
//                                catch (Exception)
//                                {
//                                    continue;
//                                }
//                            }
//                        }
//                        if (mostHits > 0)
//                        {
//                            foundHit = true;
//                        }
//                        else
//                        {
//                            foundHit = false;
//                        }
//                        if (mostHits > saveMostHits)
//                        {
//                            bestRow = i;
//                            bestCol = k;
//                            saveMostHits = mostHits;
//                        }
//                        mostHits = 0;
//                    }
//                }
//                if (foundHit = true && bestRow != int.MinValue && bestCol != int.MinValue)
//                {
//                    board[bestRow, bestCol] = "0";
//                    removedResult++;
//                }
//                saveMostHits = 0;
//                bestRow = int.MinValue;
//                bestCol = int.MinValue;
//            }
//            Console.WriteLine(removedResult);
//        }
//    }
//}


using System;

namespace knightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().ToCharArray();
            }
            int[,] possibleMooves = new int[n, n];
            int removed = 0;
            while (true)
            {
                int maxCountMoves = int.MinValue;
                int row = 0;
                int col = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (jagged[i][j] == 'K')
                        {
                            if (i - 1 > -1 && i - 1 < jagged.Length && j - 2 > -1 && j - 2 < jagged[i - 1].Length)
                            {
                                if (jagged[i - 1][j - 2] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i - 1 > -1 && i - 1 < jagged.Length && j + 2 > -1 && j + 2 < jagged[i - 1].Length)
                            {
                                if (jagged[i - 1][j + 2] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i + 1 > -1 && i + 1 < jagged.Length && j - 2 > -1 && j - 2 < jagged[i + 1].Length)
                            {
                                if (jagged[i + 1][j - 2] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i + 1 > -1 && i + 1 < jagged.Length && j + 2 > -1 && j + 2 < jagged[i + 1].Length)
                            {
                                if (jagged[i + 1][j + 2] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i - 2 > -1 && i - 2 < jagged.Length && j - 1 > -1 && j - 1 < jagged[i - 2].Length)
                            {
                                if (jagged[i - 2][j - 1] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i - 2 > -1 && i - 2 < jagged.Length && j + 1 > -1 && j + 1 < jagged[i - 2].Length)
                            {
                                if (jagged[i - 2][j + 1] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                            if (i + 2 > -1 && i + 2 < jagged.Length && j - 1 > -1 && j - 1 < jagged[i + 2].Length)
                            {
                                if (jagged[i + 2][j - 1] == 'K')
                                {
                                    possibleMooves[i, j]++;

                                }
                            }
                            if (i + 2 > -1 && i + 2 < jagged.Length && j + 1 > -1 && j + 1 < jagged[i + 2].Length)
                            {
                                if (jagged[i + 2][j + 1] == 'K')
                                {
                                    possibleMooves[i, j]++;
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (possibleMooves[i, j] > maxCountMoves)
                        {
                            maxCountMoves = possibleMooves[i, j];
                            row = i;
                            col = j;
                        }
                    }
                }
                if (maxCountMoves > 0)
                {
                    jagged[row][col] = '0';
                    removed++;
                    possibleMooves = new int[n, n];
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removed);
        }
    }
}

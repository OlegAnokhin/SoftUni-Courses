using System;
using System.Linq;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int armyRow = default;
            int armyCol = default;

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                matrix[i] = currentRow;
                if (currentRow.Contains('A'))
                {
                    armyRow = i;
                    armyCol = currentRow.ToList().IndexOf('A');
                }
            }
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                matrix[enemyRow][enemyCol] = 'O';
                armyLives--;
                matrix[armyRow][armyCol] = '-';

                if (command == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                }
                else if (command == "down" && armyRow + 1 < rows)
                {
                    armyRow++;
                }
                else if (command == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                }
                else if (command == "right" && armyCol + 1 < matrix[0].Length)
                {
                    armyCol++;
                }
                if (matrix[armyRow][armyCol] == 'O')
                {
                    armyLives -= 2;
                }
                else if (matrix[armyRow][armyCol] == 'M')
                {
                    matrix[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyLives}");
                    break;
                }
                if (armyLives <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
                matrix[armyRow][armyCol] = 'А';
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(new String(matrix[i]));
            }
        }
    }
}
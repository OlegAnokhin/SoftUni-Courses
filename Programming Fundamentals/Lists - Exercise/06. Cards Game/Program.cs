using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondHand = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstHand.Count <= 0 || secondHand.Count <= 0)
                {
                    break;
                }
                else if (firstHand[0] > secondHand[0])
                {
                    firstHand.Add(firstHand[0]);
                    firstHand.Add(secondHand[0]);
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                 else if (secondHand[0] > firstHand[0])
                {
                    secondHand.Add(secondHand[0]);
                    secondHand.Add(firstHand[0]);
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }
                else if (firstHand[0] == secondHand[0])
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
            }
            if (firstHand.Count > secondHand.Count)
            {
                int sum = firstHand.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (secondHand.Count > firstHand.Count)
            {
                int sum = secondHand.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _01.TilesMasterEXAM25._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] greyTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> whiteStack = new Stack<int>(whiteTiles);
            Queue<int> greyQueue = new Queue<int>(greyTiles);

            Dictionary<string, int> locations = new Dictionary<string, int>
        {
            {"Countertop", 0},
            {"Floor", 0},
            {"Oven", 0},
            {"Sink", 0},
            {"Wall", 0}
        };
            while (whiteStack.Count > 0 && greyQueue.Count > 0)
            {
                int currWhite = whiteStack.Peek();
                int currGrey = greyQueue.Peek();
                int sum = 0;
                if (currWhite == currGrey)
                {
                    sum = currWhite + currGrey;
                }
                else
                {
                    int numToReturn = currWhite / 2;
                    whiteStack.Pop();
                    whiteStack.Push(numToReturn);
                    greyQueue.Dequeue();
                    greyQueue.Enqueue(currGrey);
                    continue;
                }
                if (sum == 40)
                {
                    locations["Sink"]++;
                    greyQueue.Dequeue();
                    whiteStack.Pop();
                }
                else if (sum == 50)
                {
                    locations["Oven"]++;
                    greyQueue.Dequeue();
                    whiteStack.Pop();
                }
                else if (sum == 60)
                {
                    locations["Countertop"]++;
                    greyQueue.Dequeue();
                    whiteStack.Pop();
                }
                else if (sum == 70)
                {
                    locations["Wall"]++;
                    greyQueue.Dequeue();
                    whiteStack.Pop();
                }
                else
                {
                    locations["Floor"]++;
                    greyQueue.Dequeue();
                    whiteStack.Pop();
                }
            }
            if (whiteStack.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine("White tiles left: " + String.Join(", ", whiteStack));
            }
            if (greyQueue.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine("Grey tiles left: " + String.Join(", ", greyQueue));
            }
            foreach (var item in locations.OrderByDescending(b => b.Value).ThenBy(a => a.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
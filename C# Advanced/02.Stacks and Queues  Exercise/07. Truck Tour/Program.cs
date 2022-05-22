using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumpsQueue = new Queue<int[]>();

            for (int i = 0; i < pumps; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                pumpsQueue.Enqueue(input);
            }
            int startIndex = 0;
            while (true)
            {
                int totalLiters = 0;
                bool IsComplete = true;

                foreach (int[] item in pumpsQueue)
                {
                    int liters = item[0];
                    int distance = item[1];
                    totalLiters += liters;
                    if (totalLiters - distance < 0)
                    {
                        startIndex++;
                        int[] currentPump = pumpsQueue.Dequeue();
                        pumpsQueue.Enqueue(currentPump);
                        IsComplete = false;
                        break;
                    }

                    totalLiters -= distance;
                }

                if (IsComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}

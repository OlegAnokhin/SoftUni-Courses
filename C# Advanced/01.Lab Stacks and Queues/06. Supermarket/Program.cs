using System;
using System.Collections.Generic;


namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int totalRemaining = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Paid")
                {
                    foreach (var name in queue)
                    {
                        Console.WriteLine(name);
                    }
                    queue.Clear();
                    continue;
                }
                else if (input == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                queue.Enqueue(input);
                totalRemaining++;
            }
        }
    }
}

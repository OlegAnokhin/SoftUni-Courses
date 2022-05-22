using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (int element in elements)
            {
                if (element % 2 == 0)
                {
                    queue.Enqueue(element);
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            List<int> orderList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            Queue<int> ordersQueue = new Queue<int>(orderList);
            Console.WriteLine(ordersQueue.Max());
            int countOrder = ordersQueue.Count;

            for (int i = 1; i <= countOrder; i++)
            {
                if (quantityFood >= ordersQueue.Peek())
                {
                    quantityFood -= ordersQueue.Peek();
                    ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: " + string.Join(" ", ordersQueue));
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int rackCount = 1;
            int clothSum = 0;

            Stack<int> stack = new Stack<int>(numbers);

            foreach (int number in stack)
            {
                if (clothSum + number <= capacity)
                {
                    clothSum += number;
                }
                else if (clothSum + number > capacity)
                {
                    clothSum = 0;
                    clothSum += number;
                    rackCount++;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}

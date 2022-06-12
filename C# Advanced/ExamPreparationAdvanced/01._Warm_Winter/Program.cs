using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputHats = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputScarfs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>(inputHats);
            Queue<int> scarfs = new Queue<int>(inputScarfs);
            List<int> elements = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    elements.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    int value = hats.Pop() + 1;
                    hats.Push(value);
                }
            }
            Console.WriteLine($"The most expensive set is: {elements.Max()}");
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

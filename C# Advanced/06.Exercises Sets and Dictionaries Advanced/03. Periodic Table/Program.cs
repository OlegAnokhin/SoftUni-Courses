using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] chElements = input.Split(" ");
                foreach (string chElement in chElements)
                {
                    elements.Add(chElement);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

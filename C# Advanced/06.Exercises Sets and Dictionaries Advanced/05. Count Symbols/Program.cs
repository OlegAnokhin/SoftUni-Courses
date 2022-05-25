using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();

            foreach (char c in input)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary.Add(c, 1);
                }
                else
                {
                    dictionary[c]++;
                }
            }
            Console.WriteLine();
        }
    }
}

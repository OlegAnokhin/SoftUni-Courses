using System;
using System.Collections.Generic;
using System.Linq;

namespace Exe01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string splitwords = string.Empty;

            Dictionary<char, int> counts = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                splitwords = words[i];

                char[] word = splitwords.ToCharArray();

                foreach (var character in splitwords)
                {
                    if (counts.ContainsKey(character))
                    {
                        counts[character]++;
                    }
                    else
                    {
                        counts.Add(character, 1);
                    }
                }
            }
            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}

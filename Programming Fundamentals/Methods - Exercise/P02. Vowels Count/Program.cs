using System;
using System.Linq;

namespace P02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsCount = GetVowelsCount(input);

            Console.WriteLine(vowelsCount);
        }

        static int GetVowelsCount(string input)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            int vowelsCount = 0;
            foreach (char ch in input.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}


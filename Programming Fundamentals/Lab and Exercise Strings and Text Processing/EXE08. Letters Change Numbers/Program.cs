using System;
using System.Linq;

namespace EXE08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;

            foreach (string word in words)
            {
                sum += CalculateSingleWord(word);
            }

            Console.WriteLine($"{sum:F2}");
        }
        static double CalculateSingleWord(string word)
        {
            double sum = 0;

            char firstLetter = word[0];
            char lastLetter = word[word.Length - 1];    
            int num = int.Parse(word.Substring(1, word.Length - 2));

            int firstLetterPos = GetAlphabeticalPositionOfCharacter(firstLetter);
            int lastLetterPos = GetAlphabeticalPositionOfCharacter(lastLetter);

            if (firstLetterPos == -1 || lastLetterPos == -1)
            {
                return 0;
            }

            if (char.IsUpper(firstLetter))
            {
                sum = (double)num / firstLetterPos;
            }
            else if (char.IsLower(firstLetter))
            {
                sum = (double)(num * firstLetterPos);
            }
            if (char.IsUpper(lastLetter))
            {
                sum -= lastLetterPos;
            }
            else if (char.IsLower(lastLetter))
            {
                sum += lastLetterPos;
            }
            return sum;
        }
        static int GetAlphabeticalPositionOfCharacter (char ch)
        {
            if (!Char.IsLetter(ch))
            {
                return -1;
            }
            char chCI = char.ToLowerInvariant(ch);
            return (int)chCI - 96;
        }
    }
}

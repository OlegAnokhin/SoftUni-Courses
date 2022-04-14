using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex patternForEmojis = new Regex(@"([*|:]){2}(?<word>[A-Z][a-z]{2,})\1\1");
            Regex patternForDigits = new Regex(@"\d");

            string input = Console.ReadLine();

            MatchCollection matchesForEmojis = patternForEmojis.Matches(input);
            MatchCollection matchesForDigits = patternForDigits.Matches(input);
            double coolThreshold = 1;
            int EmojisCount = matchesForEmojis.Count();

            foreach (Match match in matchesForDigits)
            {
                double currNum = double.Parse(match.Groups[0].Value);
                coolThreshold *= currNum;
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{EmojisCount} emojis found in the text. The cool ones are:");

            foreach (Match match in matchesForEmojis)
            {
                double coolEmojiSum = 0;
                string emojiWord = match.Groups["word"].Value;
                foreach (char ch in emojiWord)
                {
                    coolEmojiSum += (int)ch;
                }
                if (coolEmojiSum > coolThreshold)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
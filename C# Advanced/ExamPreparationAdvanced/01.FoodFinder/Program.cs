using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowelsQueue = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToArray());
            Stack<char> consonantsStack = new Stack<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToArray());
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            int pearLength = 4;
            int flourLength = 5;
            int porkLength = 4;
            int oliveLength = 5;
            int totalWordsFound = 0;
            List<string> wordsFound = new List<string>();

            while (consonantsStack.Count > 0)
            {
                char currVowel = vowelsQueue.Dequeue();
                vowelsQueue.Enqueue(currVowel);
                char currConsonant = consonantsStack.Pop();
                if (pear.Contains(currVowel))
                {
                    pear = pear.Replace(currVowel, ' ');
                    pearLength--;
                }
                if (flour.Contains(currVowel))
                {
                    flour = flour.Replace(currVowel, ' ');
                    flourLength--;
                }
                if (pork.Contains(currVowel))
                {
                    pork = pork.Replace(currVowel, ' ');
                    porkLength--;
                }
                if (olive.Contains(currVowel))
                {
                    olive = olive.Replace(currVowel, ' ');
                    oliveLength--;
                }
                if (pear.Contains(currConsonant))
                {
                    pear = pear.Replace(currConsonant, ' ');
                    pearLength--;
                }
                if (flour.Contains(currConsonant))
                {
                    flour = flour.Replace(currConsonant, ' ');
                    flourLength--;
                }
                if (pork.Contains(currConsonant))
                {
                    pork = pork.Replace(currConsonant, ' ');
                    porkLength--;
                }
                if (olive.Contains(currConsonant))
                {
                    olive = olive.Replace(currConsonant, ' ');
                    oliveLength--;
                }
            }
            if (pearLength == 0)
            {
                totalWordsFound++;
                wordsFound.Add("pear");
            }
            if (flourLength == 0)
            {
                totalWordsFound++;
                wordsFound.Add("flour");
            }
            if (porkLength == 0)
            {
                totalWordsFound++;
                wordsFound.Add("pork");
            }
            if (oliveLength == 0)
            {
                totalWordsFound++;
                wordsFound.Add("olive");
            }
            Console.WriteLine($"Words found: {totalWordsFound}");
            foreach (var word in wordsFound)
            {
                Console.WriteLine(word);
            }
        }
    }
}
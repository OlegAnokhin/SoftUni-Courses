using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2___Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //Regex regex = new Regex(@"(=|\/)([A-Z][A-Za-z]{2,})\1");

            //MatchCollection matches = regex.Matches(input);
            //Console.Write($"Destinations: ");
            //int index = 0;
            //int matchesLengt = 0;
            //foreach (Match match in matches)
            //{
            //    index++;
            //    Console.Write($"{match.Groups[2].Value}");
            //    matchesLengt += match.Groups[2].Value.Length;
            //    if (index < matches.Count)
            //    {
            //        Console.Write(", ");
            //    }
            //}
            //Console.WriteLine();
            //Console.WriteLine($"Travel Points: {matchesLengt}");

            List<string> destinations = new List<string>();
            int travelPoints = 0;

            string input = Console.ReadLine();
            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})(\1)";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match currMatch in matches)
            {
                string currDestination = currMatch.Groups["destination"].Value;

                destinations.Add(currDestination);
                travelPoints += currDestination.Length;
            }

            Console.WriteLine($"Destinations: {String.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EXE_02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, double>();

            string[] racers = Console.ReadLine()
                .Split(", ");

            foreach (string racer in racers)
            {
                if (!dict.ContainsKey(racer))
                {
                    dict[racer] = 0;
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = string.Empty;
                double distance = 0;
                Regex regex = new Regex(@"[A-Za-z]");
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    name += match.Value;
                }
                if (dict.ContainsKey(name))
                {
                    MatchCollection matchesForDistance = Regex.Matches(input, @"[0-9]");

                    foreach (Match item in matchesForDistance)
                    {
                        distance += double.Parse(item.Value);
                    }
                    dict[name] += distance;
                }
            }
            var result = dict.OrderByDescending(x => x.Value).Take(3);
            int count = 1;

            foreach (var item in result)
            {
                string place = count == 1 ? "st" : count == 2 ? "nd" : "rd";
                Console.WriteLine($"{count}{place} place: {item.Key}");
                count++;
            }
        }
    }
}
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<day>\d{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";
            string datesStrings = Console.ReadLine();
            MatchCollection matches = Regex.Matches(datesStrings, regex);

            foreach (Match date in matches)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}

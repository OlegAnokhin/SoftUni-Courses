using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"([#|]){1}(?<product>[A-Za-z]+|[A-Za-z]+\s[A-Za-z]+)\1(?<data>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>[\d]+)\1");
            int calories = 0;

            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                string currNutrition = match.Groups["calories"].Value;
                calories += int.Parse(currNutrition);
            }
            int days = calories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match match in matches)
            {
                string currProduct = match.Groups["product"].Value;
                string currData = match.Groups["data"].Value;
                string currNutrition = match.Groups["calories"].Value;
                Console.WriteLine($"Item: {currProduct}, Best before: {currData}, Nutrition: {currNutrition}");
            }
        }
    }
}

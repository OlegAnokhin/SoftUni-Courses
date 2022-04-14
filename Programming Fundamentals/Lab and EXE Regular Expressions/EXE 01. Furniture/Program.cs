using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace EXE_01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<qnt>\d+)";
            string input = Console.ReadLine();
            double sum = 0;

            List<string> items = new List<string>();

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, regex);
                if (Regex.IsMatch(input, regex))
                {
                        string name = match.Groups["name"].Value;
                        double price = double.Parse(match.Groups["price"].Value);
                        double qnt = double.Parse(match.Groups["qnt"].Value);
                        sum += price * qnt;
                        items.Add(name);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Bought furniture:");
            if (items.Count > 0)
            {
                Console.WriteLine($"{string.Join(Environment.NewLine, items)}");
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}

//>>Sofa<<312.23!3
//>>Bench<<230!10
//>Invalid<<!5
//Purchase
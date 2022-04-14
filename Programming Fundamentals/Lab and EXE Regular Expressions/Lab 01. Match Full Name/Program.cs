using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";
            string names = Console.ReadLine();

            MatchCollection matchesNames = Regex.Matches(names, regex);
            foreach (Match name in matchesNames)
            {
                Console.Write($"{name.Value} ");
            }
            Console.WriteLine();
        }
    }
}

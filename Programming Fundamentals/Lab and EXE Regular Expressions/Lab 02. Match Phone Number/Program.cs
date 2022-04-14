using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab_02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string paterns = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string input = Console.ReadLine();

            List <string> matches = Regex
                .Matches(input, paterns)
                .Select(x => x.Value)
                .ToList();
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}

//{
//    string regex = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";
//    string names = Console.ReadLine();

//    MatchCollection matchesNames = Regex.Matches(names, regex);
//    foreach (Match name in matchesNames)
//    {
//        Console.Write($"{name.Value} ");
//    }
//    Console.WriteLine();
//}
//    }
//}

//"\+359( |-)2\1\d{3}\1\d{4}\b"
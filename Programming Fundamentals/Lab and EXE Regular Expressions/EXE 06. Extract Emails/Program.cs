using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EXE_06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";
            Regex regex = new Regex(pattern);
            MatchCollection validEmails = regex.Matches(input);
            if (regex.IsMatch(input))
            {
                foreach (Match email in validEmails)
                {
                    Console.WriteLine(email);
                }
            }
        }
    }
}
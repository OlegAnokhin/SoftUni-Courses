using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace ExamSolution02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\!(?<command>[A-Z][a-z]{2,})\!:\[(?<message>[A-Za-z]{8,})]");

            int countsInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countsInputs; i++)
            {
                string messages = Console.ReadLine();
                MatchCollection matches = pattern.Matches(messages);

                if (!pattern.IsMatch(messages))
                {
                    Console.WriteLine("The message is invalid");
                }
                else if (pattern.IsMatch(messages))
                {
                    foreach (Match match in matches)
                    {
                        string cmd = match.Groups["command"].Value;
                        string value = match.Groups["message"].Value;
                        Console.Write($"{cmd}: ");

                        foreach (char c in value)
                        {
                            Console.Write($"{(int)c} ");
                        }
                    Console.WriteLine();
                    }
                }
            }
        }
    }
}

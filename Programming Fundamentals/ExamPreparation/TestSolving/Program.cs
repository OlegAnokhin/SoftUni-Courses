using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExamSolution01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] cmdArg = cmd.Split(' ');
                string cmdType = cmdArg[0];

                if (cmdType == "Translate")
                {
                    char oldCh = char.Parse(cmdArg[1]);
                    char newCh = char.Parse(cmdArg[2]);
                    input = input.Replace(oldCh, newCh);
                    Console.WriteLine(input);
                }
                else if (cmdType == "Includes")
                {
                    string subString = cmdArg[1];
                    if (input.Contains(subString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (cmdType == "Start")
                {
                    string subString = cmdArg[1];
                    if (input.StartsWith(subString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (cmdType == "Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (cmdType == "FindIndex")
                {
                    string findIndex = cmdArg[1];
                    var result = input.LastIndexOf(findIndex);
                    Console.WriteLine(result);
                }
                else if (cmdType == "Remove")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int count = int.Parse(cmdArg[2]);
                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }
                cmd = Console.ReadLine();
            }
        }
    }
}

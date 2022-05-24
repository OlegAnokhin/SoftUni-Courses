using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            string pattern = @"(^\d)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            while (input != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (regex.IsMatch(input))
                    {
                        VIP.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                if (VIP.Contains(input))
                {
                    VIP.Remove(input);
                }
                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(VIP.Count + regular.Count);
            if (VIP.Count > 0)
            {
                foreach (string vip in VIP)
                {
                    Console.WriteLine(vip);
                }
            }
            if (regular.Count > 0)
            {
                foreach (string reg in regular)
                {
                    Console.WriteLine(reg);
                }
            }
        }
    }
}

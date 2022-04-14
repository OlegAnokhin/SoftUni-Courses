using System;
using System.Collections.Generic;
using System.Linq;

namespace Exe08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] courseArg = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string companyName = courseArg[0];
                string id = courseArg[1];

                if (!companyInfo.ContainsKey(companyName))
                {
                    companyInfo[companyName] = new List<string>();
                }

                if (!companyInfo[companyName].Contains(id))
                {
                    companyInfo[companyName].Add(id);
                }
            }
            foreach (var kvp in companyInfo)
            {
                string companyName = kvp.Key;
                List<string> id = kvp.Value;
                Console.WriteLine($"{companyName}");

                foreach (var emID in id)
                {
                    Console.WriteLine($"-- {emID}");
                }
            }
        }
    }
}
//SoftUni->AA12345
//SoftUni->CC12344
//Lenovo->XX23456
//SoftUni->AA12345
//Movement->DD11111
//End
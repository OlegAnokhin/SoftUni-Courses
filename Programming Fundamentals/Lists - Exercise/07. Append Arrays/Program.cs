using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> reversValue = new List<string>();

            for (int i = values.Count -1; i >= 0; i--)
            {
                string[] number = values[i].Split(" ");
                for (int j = 0; j < number.Length; j++)
                {
                    if (!number[j].Equals(""))
                    {
                        reversValue.Add(number[j]);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", reversValue));

        }
    }
}

using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> list = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                list.Add(name);
            }
            foreach (string name in list)
            {
                Console.WriteLine(name);
            }

          //  Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}

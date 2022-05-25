using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input.Split(' ')[0]);
            int m = int.Parse(input.Split(' ')[1]);
            
            HashSet<int> set1 = new HashSet<int>();
            for (int i = 1; i <= n; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 1; i <= m; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }
            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ", set1));
        }
    }
}

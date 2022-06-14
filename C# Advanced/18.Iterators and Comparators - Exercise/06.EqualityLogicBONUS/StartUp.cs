using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _06.EqualityLogicBONUS
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hasSet = new HashSet<Person>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));
                sortedSet.Add(person);
                hasSet.Add(person);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hasSet.Count);
        }
    }
}

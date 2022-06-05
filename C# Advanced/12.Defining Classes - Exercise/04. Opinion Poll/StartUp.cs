using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                persons.Add(new Person(name, age));
            }
            var sortedList = persons.Where(p => p.Age > 30).OrderBy(p => p.Name);
            foreach (var person in sortedList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}


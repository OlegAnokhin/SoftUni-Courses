using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elevatePerson = int.Parse(Console.ReadLine());
            int capacityPerson = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)elevatePerson / capacityPerson);

            if (elevatePerson < capacityPerson)
            {
                Console.WriteLine(courses);
            }
            else if (elevatePerson % capacityPerson == 0)
            {
                Console.WriteLine(courses);
            }
            else if (elevatePerson % capacityPerson != 0)
            {
                Console.WriteLine(courses);
            }
        }
    }
}

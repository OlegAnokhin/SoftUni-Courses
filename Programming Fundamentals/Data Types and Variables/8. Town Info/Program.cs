using System;

namespace _8._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTown = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());

            Console.WriteLine($"Town {nameOfTown} has population of {population} and area {area} square km.");
        }
    }
}

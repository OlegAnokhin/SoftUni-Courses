using System;

namespace _1._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal km = meters / 1000.0m;

            Console.WriteLine($"{km:f2}");
        }
    }
}

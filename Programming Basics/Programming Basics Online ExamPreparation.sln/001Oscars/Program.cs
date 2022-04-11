using System;

namespace _001Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallRental = int.Parse(Console.ReadLine());

            double statue = hallRental - (hallRental * 0.3);
            double catering = statue - (statue * 0.15);
            double sound = catering / 2;
            double sum = hallRental + statue + catering + sound;

            Console.WriteLine($"{sum:F2}");
        }
    }
}

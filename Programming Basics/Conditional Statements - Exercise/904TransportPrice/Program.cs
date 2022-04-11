using System;

namespace _904TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string DayOrNight = Console.ReadLine();

            if (kilometers < 20 && DayOrNight == "day")
            {
                Console.WriteLine($"{(kilometers * 0.79 + 0.70):f2}");
            }
            else if (kilometers < 20 && DayOrNight == "night")
            {
                Console.WriteLine($"{kilometers * 0.90 + 0.70:f2}");
            }
            else if (kilometers >= 20 && kilometers < 100)
            {
                Console.WriteLine($"{kilometers * 0.09:f2}");
            }
            else if (kilometers >= 100)
            {
                Console.WriteLine($"{kilometers * 0.06:f2}");
            }
        }
    }
}

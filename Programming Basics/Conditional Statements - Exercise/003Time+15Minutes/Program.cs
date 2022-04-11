using System;

namespace Time15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int Minutes15 = minutes + 15;
            int newHours = Minutes15 / 60;
            int newMinutes = Minutes15 % 60;
            int sumHours = 0;

            if (hours + newHours < 24)
            {
                sumHours = hours + newHours;
            }
            else
            {
                sumHours = (hours + newHours) % 24;

            }

            if (newMinutes < 10)
            {
                Console.WriteLine($"{sumHours}:0{newMinutes}");
            }
            else
            {
                Console.WriteLine($"{sumHours}:{newMinutes}");
            }
        }
    }
}
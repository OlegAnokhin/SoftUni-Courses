using System;

namespace _001Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour <= 23; hour++)
            {
                for (int minuts = 0; minuts <= 59; minuts++)
                {
                Console.WriteLine($"{hour}:{minuts}");
                }
            }
        }
    }
}

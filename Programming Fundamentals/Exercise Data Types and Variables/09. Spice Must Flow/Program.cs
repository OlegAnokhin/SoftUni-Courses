using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int days = 0;
            int spiceCounter = startingYield;
            int nextDaySpice = startingYield;
            int allSpice = 0;

            while (nextDaySpice >= 100)
            {
                days++;
                spiceCounter -= 26;
                nextDaySpice -= 10;
                allSpice += spiceCounter;
                spiceCounter = nextDaySpice;

                if (nextDaySpice < 100)
                {
                    allSpice -= 26;
                }
            }
            Console.WriteLine(days);
            Console.WriteLine(allSpice);
        }
    }
}

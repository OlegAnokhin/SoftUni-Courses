using System;

namespace _005Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int points = 301;
            int succeShotCounter = 0;
            int unnseccsesSHots = 0;
            string sector = Console.ReadLine();

            while (sector != "Retire")
            {
                int currentPoints = int.Parse(Console.ReadLine());
                int totalCurrentPoints = 0;

                if (sector == "Single")
                {
                    totalCurrentPoints = currentPoints;
                }
                else if (sector == "Double")
                {
                    totalCurrentPoints = currentPoints * 2;
                }
                else if (sector == "Triple")
                {
                    totalCurrentPoints = currentPoints * 3;
                }
                if (points >= totalCurrentPoints)
                {
                    points -= totalCurrentPoints;
                    succeShotCounter++;
                }
                else
                {
                    unnseccsesSHots++;
                }
                if (points == 0)
                {
                    Console.WriteLine($"{name} won the leg with {succeShotCounter} shots.");
                    break;
                }
                sector = Console.ReadLine();
            }
            if (points != 0)
            {
                Console.WriteLine($"{name} retired after {unnseccsesSHots} unsuccessful shots.");
            }
        }
    }
}


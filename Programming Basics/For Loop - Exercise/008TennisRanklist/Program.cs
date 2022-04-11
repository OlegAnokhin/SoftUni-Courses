using System;

namespace _008TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournament = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            double points = 0;
            double win = 0;

            for (int i = 1; i <= tournament; i++)
            {
                string stage = Console.ReadLine();

                if (stage == "W")
                {
                    points += 2000;
                    win++;
                }
                if (stage == "F")
                {
                    points += 1200;
                }
                if (stage == "SF")
                {
                    points += 720;
                }
            }
            double averagePoints = points / tournament;
            Console.WriteLine($"Final points: {startPoints + points}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{(win / tournament) * 100:F2}%");
        }
    }
}

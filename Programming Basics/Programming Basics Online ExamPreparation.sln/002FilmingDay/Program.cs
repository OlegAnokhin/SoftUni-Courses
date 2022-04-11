using System;

namespace _002FilmingDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForfilming = int.Parse(Console.ReadLine());
            int numOfScenes = int.Parse(Console.ReadLine());
            int duration = int.Parse(Console.ReadLine());

            double preparing = timeForfilming * 0.15;
            double needTime = numOfScenes * duration;
            double needTimeAll = preparing + needTime;

            if (timeForfilming >= needTimeAll)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeForfilming - needTimeAll)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(needTimeAll - timeForfilming)} minutes.");
            }
        }
    }
}

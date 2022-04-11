using System;

namespace _008LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seriesTime = int.Parse(Console.ReadLine());
            int lunchBreakTime = int.Parse(Console.ReadLine());


            double lunchTime = lunchBreakTime / 8.0;
            double breakTime = lunchBreakTime / 4.0;

            double timeForSerial = lunchBreakTime - (lunchTime + breakTime);

            double difference = timeForSerial - seriesTime;

            if (difference >= 0)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(difference)} minutes free time.");
            }
            else
            {
                difference = Math.Abs(difference);
                difference = Math.Ceiling(difference);
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {difference} more minutes.");
            }
        }
    }
}

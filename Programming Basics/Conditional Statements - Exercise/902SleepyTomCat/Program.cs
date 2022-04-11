using System;

namespace _902SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());

            double normForPlay = 30000;
            double PlayHolidays = holidays * 127;
            double PlayWorkDays = (365 - holidays) * 63;
            double AllPlay = PlayHolidays + PlayWorkDays;
            double leave = normForPlay - AllPlay;
            double hours = leave / 60;
            double seconds = leave % 60;
            double Hours =  Math.Abs(hours);

            if (normForPlay < AllPlay)
            {             
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Floor(Hours):f0} hours and {Math.Abs(seconds)} minutes more for play");
            }
            else if (normForPlay > AllPlay)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{Math.Floor(hours):f0} hours and {seconds} minutes less for play");
            }
        }
    }
}

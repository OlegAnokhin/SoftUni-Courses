using System;

namespace _008OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourscome = int.Parse(Console.ReadLine());
            int minutecome = int.Parse(Console.ReadLine());
            int examMinutes = hourExam * 60 + minuteExam;
            int studentMinutes = hourscome * 60 + minutecome;
            int timeDiff = studentMinutes - examMinutes;

            if (timeDiff > 0)
            {
                Console.WriteLine("Late");
                if (timeDiff < 60)
                {
                    Console.WriteLine($"{timeDiff} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{timeDiff / 60}:{timeDiff % 60:d2} hours after the start");
                }
            }
            else if (timeDiff == 0)
            {
                Console.WriteLine("On time");
            }
            else
            {
                timeDiff = Math.Abs(timeDiff);
                if (timeDiff <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{timeDiff} minutes before the start");
                }
                else
                {
                    if (timeDiff < 60)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{timeDiff:d2} minutes before the start");
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{timeDiff / 60}:{timeDiff % 60:d2} hours before the start");
                    }
                }
            }
        }
    }
}
using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberPage = int.Parse(Console.ReadLine());
            int Page = int.Parse(Console.ReadLine());
            int Days = int.Parse(Console.ReadLine());

            int alltime = NumberPage / Page;
            int HoursPerDay = alltime / Days;

            Console.WriteLine(HoursPerDay);
        }
    }
}

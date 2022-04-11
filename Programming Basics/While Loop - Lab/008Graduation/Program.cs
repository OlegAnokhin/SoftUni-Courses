using System;

namespace _008Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double year = 1;
            double averageGrade = 0;
            int fail = 0;

            while (year <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    fail++;
                    if (fail == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {year} grade");
                        return;
                    }
                    continue;
                }
                averageGrade += grade;
                year++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade / 12:F2}");
        }
    }
}

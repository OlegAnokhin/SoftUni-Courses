using System;

namespace _005Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tab = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 1; i <= tab; i++)
            {
                string web = Console.ReadLine();

                if (web == "Facebook")
                {
                    salary -= 150;
                }
                if (web == "Instagram")
                {
                    salary -= 100;
                }
                if (web == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    break;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}


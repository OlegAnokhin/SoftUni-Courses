using System;

namespace _006Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                string Name = Console.ReadLine();
                double Points = double.Parse(Console.ReadLine());

                points = points + (Name.Length * Points / 2);
                if (points >= 1250.5)
                {
                    break;
                }
            }
            if (points >= 1250.5)
            {
                Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {points:F1}!");
            }
            if (points < 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - points:F1} more!");
            }
        }
    }
}

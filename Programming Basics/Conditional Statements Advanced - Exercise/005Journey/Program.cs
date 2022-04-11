using System;

namespace _005Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string sesson = Console.ReadLine();
            double price = 0.0;
            if (budget <= 100)
            {
                if (sesson == "summer")
                {
                    price = budget * 0.3;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {price:F2}");
                }
                else
                {
                    price = budget * 0.7;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {price:F2}");
                }
            }
            else if (budget <= 1000)
            {
                if (sesson == "summer")
                {
                    price = budget * 0.4;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {price:F2}");
                }
                else
                {
                    price = budget * 0.8;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {price:F2}");
                }
            }
            else
            {
                price = budget * 0.9;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {price:F2}");
            }
        }
    }
}

using System;

namespace _005AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double Total = 0;

            while (input != "NoMoreMoney")
            {
                double num = double.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {num:F2}");
                Total += num;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {Total:F2}");
        }
    }
}

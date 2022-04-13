using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            TotalPrice(product, quantity);

            static void TotalPrice(string product, int quantity)
            {

                if (product == "coffee")
                {
                    Console.WriteLine($"{quantity * 1.50:f2}");
                }
                else if (product == "water")
                {
                    Console.WriteLine($"{quantity * 1.00:f2}");
                }
                else if (product == "coke")
                {
                    Console.WriteLine($"{quantity * 1.40:f2}");
                }
                else if (product == "snacks")
                {
                    Console.WriteLine($"{quantity * 2.00:f2}");
                }
            }
        }
    }
}

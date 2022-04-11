using System;

namespace _004fishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string sesson = Console.ReadLine();
            int numOfFisher = int.Parse(Console.ReadLine());

            double price = 0.0;

            if (sesson == "Spring")
            {
                price = 3000.0;
                if (numOfFisher <= 6)
                {
                    price = price - price * 0.1;
                }
                else if (numOfFisher <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (numOfFisher > 12)
                {
                    price = price - price * 0.25;
                }
            }
            if (sesson == "Summer" || sesson == "Autumn")
            {
                price = 4200;
                if (numOfFisher <= 6)
                {
                    price = price - price * 0.1;
                }
                else if (numOfFisher <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (numOfFisher > 12)
                {
                    price = price - price * 0.25;
                }
            }
            if (sesson == "Winter")
            {
                price = 2600;
                if (numOfFisher <= 6)
                {
                    price = price - price * 0.1;
                }
                else if (numOfFisher <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (numOfFisher > 12)
                {
                    price = price - price * 0.25;
                }
            }
            if (numOfFisher % 2 == 0 && sesson != "Autumn")
            {
                price = price - price * 0.05;
            }
            if (budget >= price)
            {
                double amount = budget - price;
                Console.WriteLine($"Yes! You have {amount:F2} leva left.");
            }
            if (budget < price)
            {
                double amount = price - budget;
                Console.WriteLine($"Not enough money! You need {amount:F2} leva.");
            }
        }
    }
}

using System;

namespace _005.smallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string article = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0.0;

            if (town == "Sofia")
            {
                if (article == "coffee")
                {
                    price = 0.50;
                }
                else if (article == "water")
                {
                    price = 0.80;
                }
                else if (article == "beer")
                {
                    price = 1.20;
                }
                else if (article == "sweets")
                {
                    price = 1.45;
                }
                else if (article == "peanuts")
                {
                    price = 1.60;
                }
            }
            if (town == "Plovdiv")
            {
                if (article == "coffee")
                {
                    price = 0.40;
                }
                else if (article == "water")
                {
                    price = 0.70;
                }
                else if (article == "beer")
                {
                    price = 1.15;
                }
                else if (article == "sweets")
                {
                    price = 1.30;
                }
                else if (article == "peanuts")
                {
                    price = 1.50;
                }
            }
            if (town == "Varna")
            {
                if (article == "coffee")
                {
                    price = 0.45;
                }
                else if (article == "water")
                {
                    price = 0.70;
                }
                else if (article == "beer")
                {
                    price = 1.10;
                }
                else if (article == "sweets")
                {
                    price = 1.35;
                }
                else if (article == "peanuts")
                {
                    price = 1.55;
                }
            }
            Console.WriteLine(quantity * price);

        }
    }
}

using System;

namespace _003newHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlover = Console.ReadLine();
            int numOfFlovers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;

            if (typeFlover == "Roses")
            {
                if (numOfFlovers > 80)
                {
                    price = numOfFlovers * 5.0;
                    price = price - price * 0.10;
                }
                else
                {
                    price = numOfFlovers * 5.0;
                }
            }
            else if (typeFlover == "Dahlias")
            {
                if (numOfFlovers > 90)
                {
                    price = numOfFlovers * 3.80;
                    price = price - price * 0.15;
                }
                else
                {
                    price = numOfFlovers * 3.80;
                }
            }
            else if (typeFlover == "Tulips")
            {
                if (numOfFlovers > 80)
                {
                    price = numOfFlovers * 2.80;
                    price = price - price * 0.15;

                }
                else
                {
                    price = numOfFlovers * 2.80;
                }
            }
            else if (typeFlover == "Narcissus")
            {
                if (numOfFlovers < 120)
                {
                    price = numOfFlovers * 3.0;
                    price = price + price * 0.15;
                }
                else
                {
                    price = numOfFlovers * 3.0;
                }
            }
            else if (typeFlover == "Gladiolus")
            {
                if (numOfFlovers < 80)
                {
                    price = numOfFlovers * 2.50;
                    price = price + price * 0.20;
                }
                else
                {
                    price = numOfFlovers * 2.50;
                }
            }
            if (budget >= price)
            {
                double amount = budget - price;
                Console.WriteLine($"Hey, you have a great garden with {numOfFlovers} {typeFlover} and {amount:F2} leva left.");
            }
            if (budget < price)
            {
                double amount = price - budget;
                Console.WriteLine($"Not enough money, you need {amount:F2} leva more.");
            }
        }
    }
}

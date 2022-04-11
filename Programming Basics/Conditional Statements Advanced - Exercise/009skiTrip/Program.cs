using System;

namespace _009skiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeroom = Console.ReadLine();
            string assessment = Console.ReadLine();
            int nights = days - 1;
            double price = 0.0;

            if (typeroom == "room for one person")
            {
                price = nights * 18.00;
                if (assessment == "positive")
                {
                    price = price + price * 0.25;
                }
                if (assessment == "negative")
                {
                    price = price - price * 0.1;
                }
            }
            else if (typeroom == "apartment")
            {
                if (days < 10)
                {
                    price = nights * 25.00;
                    price = price - price * 0.3;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = nights * 25.00;
                    price = price - price * 0.35;
                }
                else if (days > 15)
                {
                    price = nights * 25.00;
                    price = price - price * 0.5;
                }
                if (assessment == "positive")
                {
                    price = price + price * 0.25;
                }
                if (assessment == "negative")
                {
                    price = price - price * 0.1;
                }
            }
            else if (typeroom == "president apartment")
            {
                if (days < 10)
                {
                    price = nights * 35.00;
                    price = price - price * 0.1;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = nights * 35.00;
                    price = price - price * 0.15;
                }
                else if (days > 15)
                {
                    price = nights * 35.00;
                    price = price - price * 0.2;
                }
                if (assessment == "positive")
                {
                    price = price + price * 0.25;
                }
                if (assessment == "negative")
                {
                    price = price - price * 0.1;
                }
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}

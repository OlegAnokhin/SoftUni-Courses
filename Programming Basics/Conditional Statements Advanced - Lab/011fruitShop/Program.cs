using System;

namespace _011fruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string article = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0.0;
            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (article == "banana")
                    {
                        price = 2.50;
                    }
                    else if (article == "apple")
                    {
                        price = 1.20;
                    }
                    else if (article == "orange")
                    {
                        price = 0.85;
                    }
                    else if (article == "grapefruit")
                    {
                        price = 1.45;
                    }
                    else if (article == "kiwi")
                    {
                        price = 2.70;
                    }
                    else if (article == "pineapple")
                    {
                        price = 5.50;
                    }
                    else if (article == "grapes")
                    {
                        price = 3.85;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    if (article == "banana")
                    {
                        price = 2.70;
                    }
                    else if (article == "apple")
                    {
                        price = 1.25;
                    }
                    else if (article == "orange")
                    {
                        price = 0.90;
                    }
                    else if (article == "grapefruit")
                    {
                        price = 1.60;
                    }
                    else if (article == "kiwi")
                    {
                        price = 3.00;
                    }
                    else if (article == "pineapple")
                    {
                        price = 5.60;
                    }
                    else if (article == "grapes")
                    {
                        price = 4.20;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("error");
                    }
                    break;
            }
            if (price != 0)
            {
                Console.WriteLine("{0:f2}", quantity * price);
            }
        }
    }
}


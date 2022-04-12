using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coin = Console.ReadLine();
            double sumCoins = 0;

            while (coin != "Start")
            {
                if (coin == "0.1")
                {
                    sumCoins = sumCoins + double.Parse(coin);
                }
                else if (coin == "0.2")
                {
                    sumCoins = sumCoins + double.Parse(coin);
                }
                else if (coin == "0.5")
                {
                    sumCoins = sumCoins + double.Parse(coin);
                }
                else if (coin == "1")
                {
                    sumCoins = sumCoins + double.Parse(coin);
                }
                else if (coin == "2")
                {
                    sumCoins = sumCoins + double.Parse(coin);
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

                coin = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double productPrice = 0;

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    productPrice = 2.0;
                }
                else if (product == "Water")
                {
                    productPrice = 0.7;
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (product == "Soda")
                {
                    productPrice = 0.8;
                }
                else if (product == "Coke")
                {
                    productPrice = 1.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                if (sumCoins >= productPrice && sumCoins > 0 && productPrice > 0)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumCoins = sumCoins - productPrice;
                    productPrice = 0;
                }
                else if (productPrice > 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    productPrice = 0;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sumCoins:F2}");
        }
    }

}
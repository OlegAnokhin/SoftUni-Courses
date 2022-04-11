using System;

namespace _002._Bracelet_Stand
{
    class Program
    {
        static void Main(string[] args)
        {
            double pocketMoney = double.Parse(Console.ReadLine());
            double profit = double.Parse(Console.ReadLine());
            double costs = double.Parse(Console.ReadLine());
            double priceOfGift = double.Parse(Console.ReadLine());

            double savedMoney = pocketMoney * 5;
            double profitAll = profit * 5;
            double costsAll = savedMoney + profitAll - costs;

            if (costsAll >= priceOfGift)
            {
                Console.WriteLine($"Profit: {costsAll:F2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {priceOfGift - costsAll:F2} BGN.");
            }

        }
    }
}

using System;

namespace _007Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int CPU = int.Parse(Console.ReadLine());
            int RAM = int.Parse(Console.ReadLine());
            int videoPrice = videoCards * 250;
            double CPUPrice = (videoPrice * CPU) * 0.35;
            double RAMPrice = (videoPrice * RAM) * 0.10;
            double amount = videoPrice + CPUPrice + RAMPrice;
            double amountDiscount = amount - amount * 0.15;
            if (videoCards > CPU)
            {
                double moneyLeft = budget - amountDiscount;
                double moneyMore = Math.Abs(moneyLeft);
                if (moneyLeft >= 0)
                {
                    Console.WriteLine($"You have {moneyLeft:f2} leva left!");
                }
                else if (moneyLeft < 0)
                {
                    Console.WriteLine($"Not enough money! You need {moneyMore:f2} leva more!");
                }
            }
            else
            {
                double moneyleft = budget - amount;
                double neededMoney = Math.Abs(moneyleft);
                if (moneyleft >= 0)
                {
                    Console.WriteLine(($"You have {moneyleft:f2} leva left!"));
                }
                else if (moneyleft < 0)
                {
                    Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva more!");
                }
            }
        }
    }
}

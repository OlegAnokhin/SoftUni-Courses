using System;

namespace _004ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacPrice = double.Parse(Console.ReadLine());

            int puzzels = int.Parse(Console.ReadLine());
            int dolse = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            int toysCount = puzzels + dolse + bears + minions + trucks;

            double puzzelPrice = puzzels * 2.60;
            double dolsePrice = dolse * 3;
            double bearsPrice = bears * 4.10;
            double minionsPrice = minions * 8.20;
            double trucksPrice = trucks * 2;

            double profit = puzzelPrice + dolsePrice + bearsPrice + minionsPrice + trucksPrice;

            if (toysCount >= 50)
            {
                profit = profit - profit * 0.25;
            }
            profit = profit - profit * 0.1;

            double difference = profit - vacPrice;
            if (difference >= 0)
            {
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }

        }
    }
}

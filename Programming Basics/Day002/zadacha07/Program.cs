using System;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chikenmenu = int.Parse(Console.ReadLine());
            int fishmenu = int.Parse(Console.ReadLine());
            int vegeterianmenu = int.Parse(Console.ReadLine());

            double PriceChiken = chikenmenu * 10.35;
            double PriceFish = fishmenu * 12.40;
            double Pricevegan = vegeterianmenu * 8.15;
            double PriceForOrder = PriceChiken + PriceFish + Pricevegan;
            double Dessert = PriceForOrder * 0.20;
            double Delivery = 2.50;
            double total = PriceForOrder + Dessert + Delivery;

            Console.WriteLine(total);

        }
    }
}

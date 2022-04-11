using System;

namespace SuppliesforSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int penpack = int.Parse(Console.ReadLine());
            int markerpack = int.Parse(Console.ReadLine());
            int literCD = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double PricePen = penpack * 5.80;
            double PriceMarker = markerpack * 7.20;
            double PriceCD = literCD * 1.20;
            double costs = PricePen + PriceMarker + PriceCD;
            double Pricediscount = (costs * discount) / 100;
            double PriceALL = costs - Pricediscount;

            Console.WriteLine(PriceALL);
        }
    }
}

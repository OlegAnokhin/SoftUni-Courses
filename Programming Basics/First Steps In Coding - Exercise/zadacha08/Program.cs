using System;

namespace BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int PricePerYear = int.Parse(Console.ReadLine());

            double shoes = PricePerYear - (PricePerYear * 0.4);
            double cloth = shoes - (shoes * 0.2);
            double ball = cloth / 4;
            double accb = ball / 5;
            double price = PricePerYear + shoes + cloth + ball + accb;
            Console.WriteLine(price);

                }
    }
}

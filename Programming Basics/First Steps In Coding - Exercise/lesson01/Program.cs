using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nylonPrise = (nylon + 2) * 1.50;
            double paintPrice = (paint + (paint * 0.1)) * 14.50;
            double thinnerPrice = thinner * 5;
            double bag = 0.40;
            double sum = nylonPrise + paintPrice + thinnerPrice + bag;
            double hourssum = (sum * 0.3) * hours;
            double fullsum = sum + hourssum;

            Console.WriteLine(fullsum);
        }
    }
}

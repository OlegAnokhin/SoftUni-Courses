using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double capacity = length * width * height;
            double capacityLitr = capacity / 1000;
            double Ospace = percent / 100;
            double needLiters = capacityLitr * (1 - Ospace);

            Console.WriteLine(needLiters);
        }
    }
}

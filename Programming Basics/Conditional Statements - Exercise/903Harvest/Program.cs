using System;

namespace _903Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());

            double totalGrape = x * y;
            double vine = totalGrape / 2.5 * 0.4;
            double left = vine - z;
            if (vine >= z)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(vine)} liters.");
                Console.WriteLine($"{Math.Ceiling(left)} liters left -> {Math.Ceiling(left / numWorkers)} liters per person.");
            }
            else if (vine < z)
            {
                double Left = z - vine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(Left)} liters wine needed.");
            }
        }
    }
}

using System;

namespace _007AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string FigureType = Console.ReadLine();
            if (FigureType == "square")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * a:f3}");
            }
            if (FigureType == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * b:f3}");
            }
            if (FigureType == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                Console.WriteLine($"{r * r * Math.PI:f3}");
            }
            if (FigureType == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * ha / 2:f3}");
            }

        }
    }
}

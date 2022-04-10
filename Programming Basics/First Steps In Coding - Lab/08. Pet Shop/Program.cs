using System;

namespace MySecondProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogfood = int.Parse(Console.ReadLine());
            int catfood = int.Parse(Console.ReadLine());

            double area = dogfood * 2.50;
            double area2 = catfood * 4;
            double amount = area + area2;

            Console.WriteLine($"{amount} lv.");
        }
    }
}

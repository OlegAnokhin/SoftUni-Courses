using System;

namespace MySecondProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double squaremeter = double.Parse(Console.ReadLine());

            double area = squaremeter * 7.61;
            double discount = 0.18 * area;
            double amount = area - discount;

            Console.WriteLine($"The final price is: {amount} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}

using System;

namespace _006Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int apartment = int.Parse(Console.ReadLine());

            for (int a = floor; a > 0; a--)
            {
                for (int b = 0; b < apartment; b++)
                {
                    if (a % 2 == 0 && a < floor)
                    {
                        Console.Write($"O{a}{b} ");
                    }
                    if (a % 2 != 0 && a < floor)
                    {
                        Console.Write($"A{a}{b} ");
                    }
                    if (a == floor)
                    {
                        Console.Write($"L{a}{b} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

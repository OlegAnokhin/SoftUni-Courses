using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int capacity = 255;
            int sumLiters = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                int quanties = int.Parse(Console.ReadLine());

                if (sumLiters + quanties > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sumLiters += quanties;
                }
            }
            Console.WriteLine(sumLiters);
        }
    }
}
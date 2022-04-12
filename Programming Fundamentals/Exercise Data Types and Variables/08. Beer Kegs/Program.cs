using System;
using System.Numerics;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double bigestKeg = double.MinValue;
            string nameOfBigest = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius,2.0) * height;

                if (volume >= bigestKeg)
                {
                    bigestKeg = volume;
                    nameOfBigest = model;
                }
            }
            Console.WriteLine(nameOfBigest);
        }
    }
}

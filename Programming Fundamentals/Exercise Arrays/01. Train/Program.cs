using System;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] passenger = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                passenger[i] = int.Parse(Console.ReadLine());   
                sum += passenger[i];
            }
            Console.WriteLine(String.Join(" ", passenger));
            Console.WriteLine(sum);
        }
    }
}

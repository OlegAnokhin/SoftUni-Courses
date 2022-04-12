using System;

namespace _001Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] passangers = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                passangers[i] = int.Parse(Console.ReadLine());

                sum += passangers[i];
            }
            Console.WriteLine(string.Join(" ", passangers));
            Console.WriteLine(sum);
        }
    }
}

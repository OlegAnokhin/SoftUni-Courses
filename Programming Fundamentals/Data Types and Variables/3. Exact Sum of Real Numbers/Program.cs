using System;
using System.Numerics;

namespace _3._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal num = decimal.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < num; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}

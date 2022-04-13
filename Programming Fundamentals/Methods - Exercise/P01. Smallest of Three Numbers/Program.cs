using System;

namespace P01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int minNumber = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                if (num <= minNumber)
                {
                    minNumber = num;
                }
                if (i < 2)
                {
                    num = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine(minNumber);
        }
    }
}

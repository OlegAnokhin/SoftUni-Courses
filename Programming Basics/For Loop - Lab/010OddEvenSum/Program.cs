using System;

namespace _010OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < num; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += number;
                }
                else if (i % 2 != 0)
                {
                    sumOdd += number;
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            if (sumEven != sumOdd)
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}

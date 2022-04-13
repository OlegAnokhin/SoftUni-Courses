using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            var SumOfEvenDigits = GetSumOfEven(number);
            var SumOfOddDigits = GetSumOfOdd(number);
            Console.WriteLine(SumOfEvenDigits * SumOfOddDigits);
        }
        static int GetSumOfEven(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
                number /= 10;   
            }
            return sum;
        }
        static int GetSumOfOdd(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    sum += digit;
                }
                number /= 10;
            }
            return sum;
        }

    }
}

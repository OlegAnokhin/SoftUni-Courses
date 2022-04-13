using System;
using System.Numerics;

namespace P08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal firstNum = decimal.Parse(Console.ReadLine());
            decimal secondNum = decimal.Parse(Console.ReadLine());

            SumFactorial(firstNum, secondNum);
        }

        static void SumFactorial(decimal firstNum, decimal secondNum)
        {
            BigInteger firstFactorial = new BigInteger(1);
            for (decimal i = firstNum - 1; i > 1; i--)
                firstNum *= i;

            BigInteger secondFactorial = new BigInteger(1);
            for (decimal i = secondNum - 1; i > 1; i--)
                secondNum *= i;

            decimal sumFactorial = firstNum / secondNum;

            Console.WriteLine($"{sumFactorial:f2}");
        }
    }
}

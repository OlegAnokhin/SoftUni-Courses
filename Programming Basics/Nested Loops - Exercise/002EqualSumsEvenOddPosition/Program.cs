using System;

namespace _002EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int oddSum;
            int evenSum;
            string currentNum;

            for (int a = num1; a <= num2; a++)
            {
                currentNum = a.ToString();
                oddSum = 0;
                evenSum = 0;
                for (int b = 0; b < currentNum.Length; b++)
                {
                    if (b % 2 == 0)
                    {
                        evenSum += currentNum[b];
                    }
                    else
                    {
                        oddSum += currentNum[b];
                    }
                }
                if (evenSum == oddSum)
                {
                    Console.Write(currentNum + " ");
                }
            }
        }
    }
}

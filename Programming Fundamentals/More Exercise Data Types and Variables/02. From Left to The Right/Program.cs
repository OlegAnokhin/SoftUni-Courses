using System;

namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                long firstNum = long.Parse(numbers[0]);
                long secondNum = long.Parse(numbers[1]);
                if (firstNum > secondNum)
                {
                    Console.WriteLine(SumOfDigits(firstNum));
                }
                else
                {
                    Console.WriteLine(SumOfDigits(secondNum));
                }
            }
        }
        public static int SumOfDigits(long number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }
            return Math.Abs(sum);
        }
    }
}

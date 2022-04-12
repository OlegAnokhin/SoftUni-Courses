using System;

namespace _5._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                int numberToProcess = i;
                int sum = 0;
                while (numberToProcess != 0)
                {
                    int currentDigit = numberToProcess % 10;
                    numberToProcess = numberToProcess / 10;
                    sum += currentDigit;
                }
                bool IsTrue = sum == 5 || sum == 7 || sum == 11;
                    Console.WriteLine($"{i} -> {IsTrue}");
            }
        }
    }
}

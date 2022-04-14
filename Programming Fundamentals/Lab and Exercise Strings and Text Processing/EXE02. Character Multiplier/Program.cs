using System;

namespace EXE02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string leftParth = input[0];
            string rightParth = input[1];

            int minLength = Math.Min(leftParth.Length, rightParth.Length);
            int maxLength = Math.Max(leftParth.Length, rightParth.Length);
            int sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += MultiplyCharsASCII(leftParth[i], rightParth[i]);
            }

            if (leftParth.Length != rightParth.Length)
            {
                string longerInput = leftParth.Length > rightParth.Length ? longerInput = leftParth : longerInput = rightParth;
                for (int i = minLength; i < maxLength; i++)
                {
                    sum += longerInput[i];
                }
            }
            Console.WriteLine(sum);
        }

        static int MultiplyCharsASCII(char let1, char let2)
        {
            int multiply = let1 * let2;
            return multiply;
        }
    }
}
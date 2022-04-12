using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            long factorialSum = 0;

            for (int i = 0; i <= number.Length -1; i++)
            {
                char currCh = number[i];
                int currentDigit = (int)currCh - 48;

                long currDigitFacturial = 1;
                for (int r = currentDigit; r > 1; r--)
                {
                    currDigitFacturial *= r;
                }
                factorialSum += currDigitFacturial;
            }
            if (factorialSum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

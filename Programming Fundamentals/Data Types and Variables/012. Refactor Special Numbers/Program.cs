using System;

namespace _012._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            bool ItFalse = false;
            for (int ch = 1; ch <= number; ch++)
            {
               int numInWork = ch;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
                ItFalse = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{numInWork} -> {ItFalse}");
                sum = 0;
                ch = numInWork;
            }
        }
    }
}
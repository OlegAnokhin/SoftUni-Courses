using System;

namespace _004SumofTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startStep = int.Parse(Console.ReadLine());
            int finaltep = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;

            for (int a = startStep; a <= finaltep; a++)
            {
                for (int b = startStep; b <= finaltep; b++)
                {
                    counter++;
                    sum = a + b;
                    if (number == sum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({a} + {b} = {number})");
                        return;
                    }
                }
            }
            if (number != sum)
            {
                Console.WriteLine($"{counter} combinations - neither equals {number}");
                return;
            }
        }
    }
}

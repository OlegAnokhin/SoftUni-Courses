using System;

namespace _003SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num;
            int primeSum = 0;
            int nonPrimeSum = 0;
            bool isPrime;
            while (input != "stop")
            {
                num = int.Parse(input);
                isPrime = true;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");                   
                }
                else
                {
                    for (int i = 2; i < num; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            nonPrimeSum += num;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primeSum += num;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}

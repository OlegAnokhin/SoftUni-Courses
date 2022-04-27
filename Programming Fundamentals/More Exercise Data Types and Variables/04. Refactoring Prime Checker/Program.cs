using System;

namespace _04._Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int n = 2; n <= num; n++)
            {
                bool itIs = true;
                for (int range = 2; range < n; range++)
                {
                    if (n % range == 0)
                    {
                        itIs = false;
                        Console.WriteLine($"{n} -> false");
                        break;
                    }
                }
                if (itIs == true)
                {
                    Console.WriteLine($"{n} -> true");
                }
            }
        }
    }
}

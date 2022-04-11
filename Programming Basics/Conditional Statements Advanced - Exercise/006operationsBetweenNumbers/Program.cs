using System;

namespace _006operationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0.0;

            if (operation == '+' || operation == '-' || operation == '*')
            {
                string evenOrOdd = "odd";
                if (operation == '+')
                {
                    result = N1 + N2;
                }
                else if (operation == '-')
                {
                    result = N1 - N2;
                }
                else if (operation == '*')
                {
                    result = N1 * N2;
                }

                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                Console.WriteLine($"{N1} {operation} {N2} = {result} - {evenOrOdd}");
            }
            else if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else if (operation == '/')
            {
                result = 1.0 * N1 / N2;
                Console.WriteLine($"{N1} / { N2} = {result:F2}");
            }
            else
            {
                result = N1 % N2;
                Console.WriteLine($"{N1} % {N2} = {result}");
            }
        }
    }
}
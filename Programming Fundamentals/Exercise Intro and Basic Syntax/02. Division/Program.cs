using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int dividor = -1;

            if (input % 10 == 0)
            {
                dividor = 10;
            }
            else if (input % 7 ==0)
            {
                dividor = 7;
            }
            else if (input % 6 == 0)
            {
                dividor = 6;
            }
            else if (input % 3 == 0)
            {
                dividor = 3;
            }
            else if (input % 2 == 0)
            {
                dividor = 2;
            }
            if (dividor == -1)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
            Console.WriteLine($"The number is divisible by {dividor}");
            }
        }
    }
}

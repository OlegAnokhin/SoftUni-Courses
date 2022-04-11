using System;

namespace _009LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < num; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                sum1 += num1;
            }
            for (int i = 0; i < num; i++)
            {
                int num2 = int.Parse(Console.ReadLine());
                sum2 += num2;
            }
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            if (sum1 != sum2)
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1 - sum2)}");
            }
        }
    }
}

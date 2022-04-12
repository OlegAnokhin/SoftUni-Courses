using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = number;

            while (num > 0)
            {
                sum += num % 10;
                num = num / 10;
            }
            Console.WriteLine(sum);

        }
    }
}

using System;

namespace _004CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double pricewash = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            int toys = 0;
            double money = 0;
            double sum = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money = money + (i * 5 - 1);
                }
                else
                {
                    toys++;
                }
                sum = money + (toys * priceToy);
            }
            if (sum > pricewash)
            {
                Console.WriteLine($"Yes! {sum - pricewash:F2}");
            }
            if (sum < pricewash)
            {
                Console.WriteLine($"No! {pricewash - sum:F2}");
            }
        }
    }
}

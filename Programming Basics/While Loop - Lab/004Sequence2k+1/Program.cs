using System;

namespace _004Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 1;

            while (sum <= num)
            {
                Console.WriteLine(sum);
                sum = sum * 2 + 1;
            }
        }
    }
}

using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine());

            double lihva = deposit * (procent / 100);
            double lihwazamesec = lihva / 12;
            double summ = deposit + time * lihwazamesec;
            Console.WriteLine(summ);

        }
    }
}

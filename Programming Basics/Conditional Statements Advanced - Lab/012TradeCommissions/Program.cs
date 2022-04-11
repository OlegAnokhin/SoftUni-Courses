using System;

namespace _012TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double percent = 0.0;

            if (town == "Sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    percent = 5;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    percent = 7;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    percent = 8;
                }
                else if (sales > 10000)
                {
                    percent = 12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            if (town == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    percent = 4.5;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    percent = 7.5;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    percent = 10;
                }
                else if (sales > 10000)
                {
                    percent = 13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            if (town == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    percent = 5.5;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    percent = 8;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    percent = 12;
                }
                else if (sales > 10000)
                {
                    percent = 14.5;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            if (town != "Sofia" && town != "Varna" && town != "Plovdiv")
            {
                Console.WriteLine("error");
            }
            if (percent > 0)
            {
                Console.WriteLine($"{sales * percent / 100.00:f2}");
            }
        }
    }
}


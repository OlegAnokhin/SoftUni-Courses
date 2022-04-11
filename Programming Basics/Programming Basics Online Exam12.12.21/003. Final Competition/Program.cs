using System;

namespace _003._Final_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
                int dancers = int.Parse(Console.ReadLine());
                double points = double.Parse(Console.ReadLine());
                string seson = Console.ReadLine();
                string place = Console.ReadLine();
                double sum = 0;

                if (seson == "summer")
                {
                    if (place == "Bulgaria")
                    {
                        sum = (dancers * points);
                        sum = sum - sum * 0.05;
                    }
                    if (place == "Abroad")
                    {
                        sum = (dancers * points);
                        sum = sum - sum * 0.1;
                        sum += sum * 0.5;
                    }
                }
                if (seson == "winter")
                {
                    if (place == "Bulgaria")
                    {
                        sum = (dancers * points);
                        sum = sum - sum * 0.08;
                    }
                    if (place == "Abroad")
                    {
                        sum = (dancers * points);
                        sum = sum - sum * 0.15;
                        sum += sum * 0.5;
                    }
                }
                double moneyForCharity = sum * 0.75;
                double remaining = (sum - moneyForCharity) / dancers;
                Console.WriteLine($"Charity - {moneyForCharity:F2}");
                Console.WriteLine($"Money per dancer - {remaining:F2}");
            }
        }
    }
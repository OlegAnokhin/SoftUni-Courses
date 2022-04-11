using System;

namespace _006EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int customers = int.Parse(Console.ReadLine());
            double moneyspent = 0;

            for (int i = 0; i < customers; i++)
            {
                int counter = 0;
                double sum = 0;
                string input = Console.ReadLine();

                while (input != "Finish")
                {
                    counter++;
                    if (input == "basket")
                    {
                        sum += 1.50;
                    }
                    if (input == "wreath")
                    {
                        sum += 3.80;
                    }
                    if (input == "chocolate bunny")
                    {
                        sum += 7;
                    }
                    input = Console.ReadLine();
                }
                if (counter % 2 == 0)
                {
                    sum -= sum * 0.20;
                }
                moneyspent += sum;
            Console.WriteLine($"You purchased {counter} items for {sum:F2} leva.");
            }
            double average = moneyspent / customers;
            Console.WriteLine($"Average bill per client is: {average:F2} leva.");
        }
        
    }
}

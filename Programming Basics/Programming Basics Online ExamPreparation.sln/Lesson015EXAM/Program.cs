using System;

namespace preliminaryЕxam
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            double sum = 0;
            string input = Console.ReadLine();

            while (input != "closed")
            {
                switch
                
                if (input == "haircut")
                {
                    input = Console.ReadLine();
                    if (input == "mens")
                    {
                        sum += 15;
                    }
                    else if (input == "ladies")
                    {
                        sum += 20;
                    }
                    else
                    {
                        sum += 10;
                    }
                }
                if (input == "color")
                {
                    input = Console.ReadLine();
                    if (input == "touch up")
                    {
                        sum += 20;
                    }
                    else
                    {
                        sum += 30;
                    }
                }
                input = Console.ReadLine();
                if (sum >= target)
                {
                    Console.WriteLine($"You have reached your target for the day!");
                    Console.WriteLine($"Earned money: {sum}lv.");
                }
            }
            Console.WriteLine($"Target not reached! You need {target - sum}lv. more.");
            Console.WriteLine($"Earned money: {sum}lv.");

using System;

namespace _005._Hair_Salon
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
                if (sum >= target)
                {
                    Console.WriteLine($"You have reached your target for the day!");
                    Console.WriteLine($"Earned money: {sum}lv.");
                    return;
                }
                input = Console.ReadLine();

            }
            Console.WriteLine($"Target not reached! You need {target - sum}lv. more.");
            Console.WriteLine($"Earned money: {sum}lv.");
        }
    }
}
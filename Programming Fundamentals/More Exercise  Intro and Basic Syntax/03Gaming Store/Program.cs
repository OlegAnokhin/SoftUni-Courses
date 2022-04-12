using System;

namespace _03Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string gameName = Console.ReadLine();
            double sum = 0;


            while (gameName != "Game Time")
            {
                if (gameName != "OutFall 4" && gameName != "CS: OG" && gameName != "Zplinter Zell" && 
                    gameName != "Honored 2" && gameName != "RoverWatch" &&
                    gameName != "RoverWatch Origins Edition")
                {
                    Console.WriteLine("Not Found");
                }
                if (gameName == "OutFall 4")
                {
                    sum += 39.99;
                    if (balance < sum)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    Console.WriteLine($"Bought OutFall 4");
                }
                if (gameName == "CS: OG")
                {
                    sum += 15.99;
                    if (balance < sum)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    Console.WriteLine($"Bought CS: OG");
                }
                if (gameName == "Zplinter Zell")
                {
                    sum += 19.99;
                    if (balance < sum)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    Console.WriteLine($"Bought Zplinter Zell");
                }
                if (gameName == "Honored 2")
                {
                    sum += 59.99;
                    if (balance < sum)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    Console.WriteLine($"Bought Honored 2");
                }
                if (gameName == "RoverWatch")
                {
                    sum += 29.99;
                    if (balance < sum)
                    {
                        Console.WriteLine("Too Expensive");
                        sum -= 29.99;
                    }
                    Console.WriteLine($"Bought RoverWatch");
                }
                if (gameName == "RoverWatch Origins Edition")
                {
                    sum += 39.99;
                    if (balance < sum)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    Console.WriteLine($"Bought RoverWatch Origins Edition");
                }
                gameName = Console.ReadLine();
            }
            Console.WriteLine($"Total spend: ${sum:F2}. Remaining: ${balance - sum:F2}");
        }
    }
}

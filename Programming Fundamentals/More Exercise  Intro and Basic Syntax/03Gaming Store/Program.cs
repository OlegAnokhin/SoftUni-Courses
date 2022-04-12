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
                    double price = 39.99;
                    if (balance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        sum += 39.99;
                        balance -= price;
                        Console.WriteLine($"Bought OutFall 4");
                    }
                }
                else if (gameName == "CS: OG")
                {
                    double price = 15.99;
                    if (balance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        sum += 15.99;
                        balance -= price;
                        Console.WriteLine($"Bought CS: OG");
                    }
                }
                else if (gameName == "Zplinter Zell")
                {
                    double price = 19.99;
                    if (balance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        sum += 19.99;
                        balance -= price;
                        Console.WriteLine($"Bought Zplinter Zell");
                    }
                }
                else if (gameName == "Honored 2")
                {
                    double price = 59.99;
                    if (balance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        sum += 59.99;
                        balance -= price;
                        Console.WriteLine($"Bought Honored 2");
                    }
                }
                else if (gameName == "RoverWatch")
                {
                    double price = 29.99;
                    if (balance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        sum += 29.99;
                        balance -= price;
                        Console.WriteLine($"Bought RoverWatch");
                    }
                }
                else if (gameName == "RoverWatch Origins Edition")
                {
                    double price = 39.99;
                    if (balance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        sum += 39.99;
                        balance -= price;
                        Console.WriteLine($"Bought RoverWatch Origins Edition");
                    }
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                gameName = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${sum:F2}. Remaining: ${balance:F2}");
        }
    }
}

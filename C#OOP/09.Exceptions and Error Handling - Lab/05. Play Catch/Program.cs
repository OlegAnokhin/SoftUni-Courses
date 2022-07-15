using System;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int excCount = 0;
            while (excCount < 3)
            {
                var command = Console.ReadLine().Split();
                try
                {
                    if (command[0] == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int value = int.Parse(command[2]);
                        input[index] = value;
                    }
                    else if (command[0] == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        int length = endIndex - startIndex + 1;
                        Console.WriteLine(String.Join(", ", input.GetRange(startIndex, length)));
                    }
                    else if (command[0] == "Show")
                    {
                        int index = int.Parse(command[1]);
                        Console.WriteLine(input[index]);
                    }
                }
                catch
                {
                    if (command.Length > 2)
                    {
                        int check = 0;
                        if (int.TryParse(command[1], out check) &&
                            int.TryParse(command[2], out check))
                        {
                            Console.WriteLine("The index does not exist!");
                        }
                        else
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                        }
                    }
                    else
                    {
                        int check = 0;
                        if (int.TryParse(command[1], out check))
                        {
                            Console.WriteLine("The index does not exist!");
                        }
                        else
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                        }
                    }
                    excCount++;
                }
            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
using System;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] splitedCommands = command.Split(":|:");
                string splitedCommand = splitedCommands[0];

                if (splitedCommand == "InsertSpace")
                {
                    int index = int.Parse(splitedCommands[1]);
                    string value = " ";
                    input = input.Insert(index, value);
                    Console.WriteLine(input);
                }
                else if (splitedCommand == "Reverse")
                {
                    string subString = (splitedCommands[1]);

                    if (input.Contains(subString))
                    {
                        string reversedString = string.Empty;
                        var index = input.IndexOf(subString);
                        input = input.Remove(index, subString.Length);
                        for (int i = subString.Length - 1; i >= 0; i--)
                        {
                            reversedString += subString[i];
                        }
                        input = input.Insert(input.Length, reversedString);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (splitedCommand == "ChangeAll")
                {
                    input = input.Replace(splitedCommands[1], splitedCommands[2]);
                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}

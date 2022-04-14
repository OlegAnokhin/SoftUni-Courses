using System;
using System.Linq;

namespace _01._Secret_Chat_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] commandArgs = command.Split(":|:");
                string commandType = commandArgs[0];
                if (commandType == "InsertSpace")
                {
                    int insertIndex = int.Parse(commandArgs[1]);
                    message = message.Insert(insertIndex, " ");
                }
                else if (commandType == "Reverse")
                {
                    string subString = commandArgs[1];
                    if (message.Contains(subString))
                    {
                        int wordIndex = message.IndexOf(subString);
                        message = message.Remove(wordIndex, subString.Length);
                        message = message + string.Join("", subString.Reverse());
                    }
                    else
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else if (commandType == "ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacementText = commandArgs[2];
                    message = message.Replace(substring, replacementText);
                }
                Console.WriteLine(message);
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}

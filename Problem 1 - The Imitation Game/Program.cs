using System;
using System.Text;

namespace Problem_1___The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder(input);
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] splitedCommands = command.Split("|");

                if (splitedCommands[0] == "ChangeAll")
                {
                    result.Replace(splitedCommands[1], splitedCommands[2]);
                }
                else if (splitedCommands[0] == "Insert")
                {
                    int index = int.Parse(splitedCommands[1]);
                    string value = splitedCommands[2];
                    result.Insert(index, value);
                }
                else if (splitedCommands[0] == "Move")
                {
                    int number = int.Parse(splitedCommands[1]);
                    string subString = result.ToString().Substring(0,number);
                    result.Remove(0, number);
                    result.Append(subString);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {result}");
        }
    }
}

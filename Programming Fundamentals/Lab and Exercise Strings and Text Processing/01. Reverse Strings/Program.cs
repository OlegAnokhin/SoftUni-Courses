using System;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                string reversed = string.Empty;
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reversed += line[i];
                }
                Console.WriteLine($"{line} = {reversed}");
                line = Console.ReadLine();
            }
        }
    }
}


//string command = Console.ReadLine();
//while (command != "end")
//{
//    char[] wordArr = command.ToCharArray();
//    Array.Reverse(wordArr);
//    string reversedWord = new string(wordArr);
//    Console.WriteLine($"{command} = {reversedWord}");
//    command = Console.ReadLine();
//}
using System;

namespace P06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(TakeMiddleCh(input));
        }
        static string TakeMiddleCh (string input)
        {

            int character = input.Length;
            string result = "";

            if (character % 2 == 1)
            {
                result = input[input.Length / 2].ToString();
            }
            else
            {
                result = input[input.Length / 2 - 1].ToString() + input[input.Length / 2].ToString();
            }

            return result;
        }        
    }
}
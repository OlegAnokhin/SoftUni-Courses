using System;

namespace Exercise_Data_Types_and_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // exircise 01
            int parsedNum;
            bool isInteger = int.TryParse(Console.ReadLine(), out parsedNum);

            if (isInteger)
            {
                Console.WriteLine($"The text was the integer: {parsedNum}");
            }
            else
            {
                Console.WriteLine("The text was not integer");
            }
        }
    }
}

using System;
using System.Text;

namespace EXE05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int reminder = 0;
            int currMultiplication = 0;

            StringBuilder result = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int currDigit = input[i] - '0';
                currMultiplication = currDigit * number;
                currMultiplication += reminder;
                result.Insert(0,currMultiplication % 10);
                reminder = currMultiplication / 10;
            }
            if (reminder > 0)
            {
                result.Insert(0,reminder);
            }
            
            Console.Write(result.ToString());
        }
    }
}

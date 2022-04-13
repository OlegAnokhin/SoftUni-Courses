using System;
using System.Linq;

namespace P09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            bool IsPolidromeInteger = false;            

            while (number != "END")
            {
                Console.WriteLine(CheckPalidome(number, IsPolidromeInteger)
                    .ToString()
                    .ToLower());
                number = Console.ReadLine();
            }

            static bool CheckPalidome(string number, bool IsPalidromeInteger)
            {
                string reverseNumber = "";
                for (int i = number.Length -1; i >= 0; i--)
                {
                    char symbol = number[i];
                    reverseNumber += number[i];
                }
                if (reverseNumber == number)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder letters = new StringBuilder();
            StringBuilder numbers = new StringBuilder();
            StringBuilder otherChars = new StringBuilder();

            string text = Console.ReadLine();

            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    letters.Append(item);
                }
                else if (char.IsDigit(item))
                {
                    numbers.Append(item);
                }
                else
                {
                    otherChars.Append(item);
                }
            }
            Console.WriteLine(numbers.ToString());
            Console.WriteLine(letters.ToString());
            Console.WriteLine(otherChars.ToString());
        }
    }
}

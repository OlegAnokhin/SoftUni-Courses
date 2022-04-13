using System;
using System.Text;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string temlate = Console.ReadLine();
            int reapeat = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(temlate, reapeat));
        }

        static string RepeatString (string template , int numberOfRepeates)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < numberOfRepeates; i++)
            {
                result.Append(template);
            }
            return result.ToString();  
        }
    }
}

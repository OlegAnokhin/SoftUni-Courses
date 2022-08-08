using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            List<int> numbers = new List<int>();
            while (numbers.Count != 10)
            {
                try
                {
                    start = ReadNumber(start, end);
                    numbers.Add(start);
                }
                catch (Exception Exc)
                {
                    Console.WriteLine(Exc.Message);
                }
            }
            Console.WriteLine(String.Join(", ", numbers));

        }
        public static int ReadNumber(int start, int end)
        {
            string num = Console.ReadLine();
            if (!int.TryParse(num, out int result))
            {
                throw new FormatException("Invalid Number!");
            }
            if (result <= start || result >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
            return result;
        }
    }
}
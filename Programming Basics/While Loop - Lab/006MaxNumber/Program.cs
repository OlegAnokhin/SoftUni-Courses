using System;

namespace _006MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int maxNum = int.MinValue;

            while (text != "Stop")
            {
                int number = int.Parse(text);
                if (number >= maxNum)
                {
                maxNum = number;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}

using System;

namespace _007MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int mimNum = int.MaxValue;

            while (text != "Stop")
            {
                int number = int.Parse(text);
                if (number <= mimNum)
                {
                    mimNum = number;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(mimNum);
        }
    }
}

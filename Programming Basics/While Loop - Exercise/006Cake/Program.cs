using System;

namespace _006Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            string length = Console.ReadLine();
            string width = Console.ReadLine();
            string input = "";
            double size = 0;
            double enter = 0;
            double length1 = double.Parse(length);
            double width1 = double.Parse(width);
            size = length1 * width1;
            double count = size;

            while (length != "STOP")
            {
                input = Console.ReadLine();
                if (input == "STOP")
                {
                    Console.WriteLine($"{count} pieces are left.");
                    return;
                }
                enter = double.Parse(input);
                count = count - enter;
                if (size >= 0)
                {
                    size -= enter;
                }
                if (size <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(size)} pieces more.");
                    break;
                }
            }
        }
    }
}

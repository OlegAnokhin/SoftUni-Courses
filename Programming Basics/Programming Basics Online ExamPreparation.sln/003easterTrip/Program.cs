using System;

namespace _003EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string data = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double sum = 0;

            if (destination == "France")
            {
                if (data == "21-23")
                {
                    sum = days * 30;
                }
                else if (data == "24-27")
                {
                    sum = days * 35;
                }
                else
                {
                    sum = days * 40;
                }
            }
            if (destination == "Italy")
            {
                if (data == "21-23")
                {
                    sum = days * 28;
                }
                else if (data == "24-27")
                {
                    sum = days * 32;
                }
                else
                {
                    sum = days * 39;
                }
            }
            if (destination == "Germany")
            {
                if (data == "21-23")
                {
                    sum = days * 32;
                }
                else if (data == "24-27")
                {
                    sum = days * 37;
                }
                else
                {
                    sum = days * 43;
                }
            }
            Console.WriteLine($"Easter trip to {destination} : {sum:F2} leva.");
        }
    }
}

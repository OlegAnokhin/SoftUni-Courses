using System;

namespace _007Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int leght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            int space = leght * width * hight;
            int counter = space;
            int enter = 0;
            int freeSpace = 0;

            while (space >= 0)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    Console.WriteLine($"{counter} Cubic meters left.");
                    break;
                }
                enter = int.Parse(input);
                counter -= enter;
                if (counter <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(counter)} Cubic meters more.");
                    break;
                }
            }
        }
    }
}

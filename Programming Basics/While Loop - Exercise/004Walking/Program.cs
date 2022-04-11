using System;

namespace _004Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int steps = 0;

            while (true)
            {
                if (input == "Going home")
                {
                    steps += int.Parse(Console.ReadLine());
                    break;
                }
                steps += int.Parse(input);
                if (steps >= 10000)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (steps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
        }
    }
}

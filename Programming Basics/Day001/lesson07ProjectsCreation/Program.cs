using System;

namespace MySecondProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string NameofArchitect = Console.ReadLine();
            int numberprojects = int.Parse(Console.ReadLine());
            int area = numberprojects * 3;

            Console.WriteLine($"The architect {NameofArchitect} will need {area} hours to complete {numberprojects} project/s.");
        }
    }
}

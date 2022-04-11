using System;

namespace Еxercise006
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade < 2 || grade > 6)
            {
                Console.WriteLine("Wrong grade !");
            }
            if (grade >= 5.50 && grade < 6)
            {
                Console.WriteLine("Exellent !");
            }
            if (grade > 2 && grade < 5.50)
            {
                Console.WriteLine("Low score !");
            }
        }
    }
}

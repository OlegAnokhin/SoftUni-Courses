using System;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double centimeturs = double.Parse(Console.ReadLine());

            centimeturs *= 2.54;

            Console.WriteLine(centimeturs);
        }

    }
}


using System;

namespace Lesson014
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int line = 1; line <= num; line++)
            {
                for (int cols = 1; cols <= line; cols++)
                {
                    if (counter > num)
                    {
                        break;
                    }
                    Console.Write(counter + " ");
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }
}

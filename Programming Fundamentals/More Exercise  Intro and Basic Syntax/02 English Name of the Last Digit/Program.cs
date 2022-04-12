using System;

namespace _02_English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int lastNum = 0;


            lastNum = lastNum + (number % 10);

            if (lastNum == 1)
            {
            Console.WriteLine("one");
            }
            if (lastNum == 2)
            {
                Console.WriteLine("two");
            }
            if (lastNum == 3)
            {
                Console.WriteLine("three");
            }
            if (lastNum == 4)
            {
                Console.WriteLine("four");
            }
            if (lastNum == 5)
            {
                Console.WriteLine("five");
            }
            if (lastNum == 6)
            {
                Console.WriteLine("six");
            }
            if (lastNum == 7)
            {
                Console.WriteLine("seven");
            }
            if (lastNum == 8)
            {
                Console.WriteLine("eight");
            }
            if (lastNum == 9)
            {
                Console.WriteLine("nine");
            }
            if (lastNum == 0)
            {
                Console.WriteLine("zero");
            }
        }
    }
}

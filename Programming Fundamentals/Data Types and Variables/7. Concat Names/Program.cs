using System;

namespace _7._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimter = Console.ReadLine();


            Console.WriteLine($"{firstName}{delimter}{secondName}");
        }
    }
}

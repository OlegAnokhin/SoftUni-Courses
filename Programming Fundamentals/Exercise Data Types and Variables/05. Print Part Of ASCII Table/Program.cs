using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine()); 
            int finish = int.Parse(Console.ReadLine());

            for (int i = start; i <= finish; i++)
            {
                char currCh = (char)i;
                Console.Write($"{currCh} ");
            }
        }
    }
}

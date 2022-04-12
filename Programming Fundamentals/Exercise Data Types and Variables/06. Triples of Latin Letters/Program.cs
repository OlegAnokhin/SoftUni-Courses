using System;

namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (char a = 'a'; a < 'a' + num; a++)
            {
                for (char b = 'a'; b < 'a' + num; b++)
                {
                    for (char c = 'a'; c < 'a' + num; c++)
                    {
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
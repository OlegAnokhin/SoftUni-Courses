using System;

namespace P03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());

            CharactersInRange(firstCh, secondCh);
        }

        static void CharactersInRange(char firstCh, char secondCh)
        {
            int startCh = Math.Min(firstCh, secondCh);
            int endCh = Math.Max(firstCh, secondCh);

            for (int i = startCh + 1; i < endCh; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
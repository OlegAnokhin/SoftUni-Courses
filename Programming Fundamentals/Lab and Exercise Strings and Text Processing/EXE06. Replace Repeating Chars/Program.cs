using System;
using System.Collections.Generic;
using System.Linq;

namespace EXE06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {
                char currChar = input[i];
                char nextChar = input[i + 1];
                if (currChar == nextChar)
                {
                    input.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join("", input));

        }
    }
}

//var letters = new HashSet<char>(input);
//foreach (char c in letters)
//    Console.Write(c);
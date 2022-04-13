using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
            int result = 0;
            int removedElement = 0;
            while (input.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                int lastElement = input[input.Count - 1];
                int firstElement = input[0];

                if (index < 0)
                {
                    removedElement = firstElement;
                    input.RemoveAt(0);
                    input.Insert(0, lastElement);
                }
                else if (index > input.Count - 1)
                {
                    removedElement = lastElement;
                    input.RemoveAt(input.Count - 1);
                    input.Add(firstElement);
                }
                else
                {
                    removedElement = input[index];
                    input.RemoveAt(index);

                }
                result += removedElement;

                for (int i = 0; i < input.Count; i++)
                {
                    int currentNumber = input[i];
                    if (currentNumber <= removedElement)
                    {
                        currentNumber += removedElement;
                        input[i] = currentNumber;
                    }
                    else
                    {
                        currentNumber -= removedElement;
                        input[i] = currentNumber;

                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
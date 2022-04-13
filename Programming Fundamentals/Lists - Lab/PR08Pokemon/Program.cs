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
//List<int> pokemons = Console.ReadLine()
//    .Split()
//    .Select(int.Parse)
//    .ToList();

//int sumOfRemovedElements = 0;

//while (pokemons.Count > 0)
//{
//    int index = int.Parse(Console.ReadLine());

//    if (index < 0)
//    {
//        var removedNumberCase1 = pokemons[0];
//        sumOfRemovedElements += removedNumberCase1;
//        pokemons[0] = pokemons[pokemons.Count - 1];
//        for (int i = 0; i < pokemons.Count; i++)
//        {
//            if (pokemons[i] <= removedNumberCase1)
//            {
//                pokemons[i] += removedNumberCase1;
//            }
//            else
//            {
//                pokemons[i] -= removedNumberCase1;
//            }
//        }
//    }
//    else if (index >= pokemons.Count)
//    {
//        var removedNumberCase2 = pokemons[pokemons.Count - 1];
//        sumOfRemovedElements += removedNumberCase2;
//        pokemons[pokemons.Count - 1] = pokemons[0];
//        for (int i = 0; i < pokemons.Count; i++)
//        {
//            if (pokemons[i] <= removedNumberCase2)
//            {
//                pokemons[i] += removedNumberCase2;
//            }
//            else
//            {
//                pokemons[i] -= removedNumberCase2;
//            }
//        }
//    }
//    else
//    {
//        var removedNumberCase3 = pokemons[index];
//        sumOfRemovedElements += removedNumberCase3;
//        pokemons.RemoveAt(index);

//        for (int i = 0; i < pokemons.Count; i++)
//        {
//            if (pokemons[i] <= removedNumberCase3)
//            {
//                pokemons[i] += removedNumberCase3;
//            }
//            else
//            {
//                pokemons[i] -= removedNumberCase3;
//            }
//        }
//    }
//}
//Console.WriteLine(sumOfRemovedElements);

using System;
using System.Linq;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split(' ');

            string[] secondArr = Console.ReadLine().Split(' ');

            for (int a = 0; a < secondArr.Length; a++)
            {
                for (int b = 0; b < firstArr.Length; b++)
                {
                    if (secondArr[a] == firstArr[b])
                    {
                        Console.Write($"{secondArr[a]} ");
                    }
                }
            }
            Console.WriteLine();
        }

        static void Test()
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            for (int a = 0; a < arr2.Length; a++)
            {
                for (int b = 0; b < arr1.Length; b++)
                {
                    if (arr2[a] == arr1[b])
                    {
                        Console.Write($"{arr2[a]} ");
                    }
                }
            }
        }
    }
}


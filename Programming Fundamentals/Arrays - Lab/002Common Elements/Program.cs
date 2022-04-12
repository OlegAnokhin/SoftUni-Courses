using System;

namespace _002Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(' ');

            string[] secondArray = Console.ReadLine().Split(' ');

            for (int a = 0; a < secondArray.Length; a++)
            {
                for (int b = 0; b < firstArray.Length; b++)
                {
                    if (secondArray[a] == firstArray[b])
                    {
                        Console.Write(secondArray[a] + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

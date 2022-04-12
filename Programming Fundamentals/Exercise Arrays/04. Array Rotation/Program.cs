using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotationCounter = int.Parse(Console.ReadLine());
            int rotationCountReduced = rotationCounter % arr.Length;

            for (int rot = 1; rot <= rotationCounter; rot++)
            {
                int firstEl = arr[0];

                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[arr.Length - 1] = firstEl;
            }
            Console.WriteLine(String.Join(" " , arr));
        }
    }
}

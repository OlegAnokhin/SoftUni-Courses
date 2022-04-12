using System;

namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] rawinput = Console.ReadLine().Split();
            int [] items = new int[rawinput.Length];
            int evenSum = 0;  
            int oddSum = 0;

            for (int i = 0; i < rawinput.Length; i++)
            {
                items[i] = int.Parse(rawinput[i]);
            }
            foreach (int item in items)
            {
                if (item % 2 == 0)
                {
                    evenSum += item;
                }
                else
                {
                    oddSum += item;
                }
            }
                Console.WriteLine(evenSum - oddSum);
        }
    }
}

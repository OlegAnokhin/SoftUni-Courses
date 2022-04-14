using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string remove = Console.ReadLine();
            string input = Console.ReadLine();

            while (input.Contains(remove))
            {
                //int startIndexToRemove = input.IndexOf(remove);

                //input = input.Remove(startIndexToRemove, remove.Length);

                input = input.Replace(remove, "");
            }
            Console.WriteLine(input);
        }
    }
}

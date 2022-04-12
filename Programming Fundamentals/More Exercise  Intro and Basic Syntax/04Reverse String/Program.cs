using System;
using System.Linq;

namespace _04Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            var reversWord = chars.Reverse();


            Console.WriteLine(string.Join("", reversWord));
        }
    }
}

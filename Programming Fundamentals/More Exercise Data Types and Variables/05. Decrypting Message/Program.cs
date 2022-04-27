using System;
using System.Collections.Generic;

namespace _05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            List<char> decryptMessage = new List<char>();
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int decryptletter = letter + key;
                decryptMessage.Add((char)decryptletter);
            }
            Console.WriteLine(decryptMessage.ToArray());
        }
    }
}

using System;
using System.Text;

namespace EXE04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currCh = input[i];
                int indextCh = currCh + 3;
                char encryptCh = (char)indextCh;
                encrypted.Append(encryptCh);
            }
            Console.Write(encrypted.ToString());
        }
    }
}

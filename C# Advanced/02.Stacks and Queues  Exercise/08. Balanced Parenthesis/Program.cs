using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openBrackets = new Stack<char>();
            bool areBalance = false;

            foreach (char bracket in input)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    openBrackets.Push(bracket);
                }
                else if (bracket == '}' || bracket == ']' || bracket == ')')
                {
                    if (openBrackets.Count == 0)
                    {
                        areBalance = false;
                        break;
                    }
                    char lastOpen = openBrackets.Pop();
                    if (lastOpen == '{' && bracket == '}')
                    {
                        areBalance = true;
                    }
                    else if (lastOpen == '[' && bracket == ']')
                    {
                        areBalance = true;
                    }
                    else if (lastOpen =='(' && bracket == ')')
                    {
                        areBalance = true;
                    }
                    else
                    {
                        areBalance = false;
                        break;
                    }
                }
            }
            if (areBalance)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

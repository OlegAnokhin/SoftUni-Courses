using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Reverse());

            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (oper.Equals("+"))
                {
                    stack.Push((num1 + num2).ToString());
                }
                else if (oper.Equals("-"))
                {
                    stack.Push((num1 - num2).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
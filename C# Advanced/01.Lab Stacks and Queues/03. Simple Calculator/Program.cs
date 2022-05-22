using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input);

            //foreach (var arg in input)
            //{
            //    stack.Push(arg);
            //}

           // string[] cmd = input.Split(' ');
            int sum = 0;

            for (int i = 0; i < input.Length; i++) 
            {
                int currNumber = int.Parse(input[i]);
                string opr = input[i+1];

                if (opr == "+")
                {
                    sum += currNumber;
                }
                else if (opr == "-")
                {
                    sum -= currNumber;
                }
            }

            // stack.Push(c);
            Console.WriteLine(sum);
        }
    }
}
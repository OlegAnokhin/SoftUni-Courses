using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];

                if (cmd == "1")
                {
                    int currNum = int.Parse(input[1]);
                    stack.Push(currNum);
                }
                else if (cmd == "2")
                {
                    if (stack.Count <= 0)
                    {
                        continue;
                    }
                    stack.Pop();
                }
                else if (cmd == "3")
                {
                    if (stack.Count <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (cmd == "4")
                {
                    if (stack.Count <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}

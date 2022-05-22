using System;
using System.Collections.Generic;

namespace Stacks_and_Queues__Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1); //dobawq otgore
            stack.Pop(); // premahwa otgore
            Console.WriteLine(stack.Peek()); // pokazwa naj gorniq

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1); //dobawq w kraq na opashkata
            queue.Dequeue(); // premahwa pyrwiq ot opashkata
            Console.WriteLine(queue.Peek()); //pokazwa pyrwiq ot opashkata
        }
    }
}

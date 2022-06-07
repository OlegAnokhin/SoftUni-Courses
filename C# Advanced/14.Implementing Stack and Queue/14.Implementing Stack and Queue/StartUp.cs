using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _14.Implementing_Stack_and_Queue
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new MyList();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);

            Console.WriteLine($"Count after add - {myList.Count}");

            int removedEl = myList.RemoveAt(2);

            Console.WriteLine($"Removed element - {removedEl}");
            Console.WriteLine($"Count after remove - {myList.Count}");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"elements in list - {myList[i]}");
            }

            Console.WriteLine($"is number 10 on the list {myList.Contains(10)}");
            Console.WriteLine($"is number 1 on the list {myList.Contains(1)}");
            Console.WriteLine();
            Console.WriteLine($"Testin clear method");
            myList.Clear();
            Console.WriteLine($"List count after clean {myList.Count}");

            var testInsert = new MyList();
            testInsert.Add(11);
            testInsert.Add(22);

            testInsert.Insert(1, 55);

            Console.WriteLine($"Inserted index 1 in now {testInsert[1]}");
            for (int i = 0; i < testInsert.Count; i++)
            {
                Console.WriteLine(testInsert[i]);
            }

            var swapTest = new MyList();
            swapTest.Add(111);
            swapTest.Add(222);
            swapTest.Add(333);

            for (int i = 0; i < swapTest.Count; i++)
            {
                Console.WriteLine($"EL in list {swapTest[i]}");
            }
            swapTest.Swap(0, 1);
            Console.WriteLine($"Swap test first EL {swapTest[0]}");
            Console.WriteLine($"Swap test second EL {swapTest[1]}");
            Console.WriteLine();

            Console.WriteLine("TESTING STACK");
            ////STACK//////

            var stack = new MyStack();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Peek());
            int popedItem = stack.Pop();
            Console.WriteLine(popedItem);
            Console.WriteLine(stack.Count);

            var NewStack = new MyStack();
            for (int i = 0; i <= 10; i++)
            {
                NewStack.Push(i);
            }
            NewStack.ForEach(n => Console.WriteLine($"Number {n}"));
        }
    }
}

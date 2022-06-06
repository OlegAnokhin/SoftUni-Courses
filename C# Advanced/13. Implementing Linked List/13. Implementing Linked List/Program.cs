using System;
using System.Linq;
using System.Collections.Generic;

namespace _Implementing_Linked_List
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var linkedList = new DoublyLinkedList<int>();

            linkedList.AddHead(1);
            linkedList.AddHead(2);
            linkedList.AddHead(3);
            linkedList.AddTail(4);

            linkedList.ForEach(n => Console.WriteLine(n));

            var list = linkedList.ToList();

            var array = linkedList.ToArray();


            Console.WriteLine($"Head; {linkedList.Head.Value}");
            Console.WriteLine($"Tail; {linkedList.Tail.Value}");

            Console.WriteLine($"Next to head {linkedList.Head.Next.Value}");
            Console.WriteLine($"Previons to tail {linkedList.Head.Next.Value}");

            var removedHead = linkedList.RemoveHead();
            Console.WriteLine($"Removed head: {removedHead}");
            Console.WriteLine($"Head after removal: {linkedList.Head.Value}");

            var removedTail = linkedList.RemoveTail();
            Console.WriteLine($"Removed tail: {removedTail}");
            Console.WriteLine($"Tail after removal: {linkedList.Tail.Value}");

            var horo = new DoublyLinkedList<string>();
            horo.AddHead("Ivan");
            horo.AddHead("Gergana");
            horo.AddHead("Pesho");
            horo.AddTail("Ivana");

            horo.ForEach(p => Console.WriteLine(p));

        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var linkedList = new DoublyLinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddLast(4);

            linkedList.ForEach(n => Console.WriteLine(n));

            var list = linkedList.ToList();

            var array = linkedList.ToArray();


            Console.WriteLine($"Head; {linkedList.Head.Value}");
            Console.WriteLine($"Tail; {linkedList.Tail.Value}");

            Console.WriteLine($"Next to head {linkedList.Head.Next.Value}");
            Console.WriteLine($"Previons to tail {linkedList.Head.Next.Value}");

            var removedHead = linkedList.RemoveFirst();
            Console.WriteLine($"Removed head: {removedHead}");
            Console.WriteLine($"Head after removal: {linkedList.Head.Value}");

            var removedTail = linkedList.RemoveLast();
            Console.WriteLine($"Removed tail: {removedTail}");
            Console.WriteLine($"Tail after removal: {linkedList.Tail.Value}");

            var horo = new DoublyLinkedList<string>();
            horo.AddFirst("Ivan");
            horo.AddFirst("Gergana");
            horo.AddFirst("Pesho");
            horo.AddLast("Ivana");

            horo.ForEach(p => Console.WriteLine(p));


        }
    }
}
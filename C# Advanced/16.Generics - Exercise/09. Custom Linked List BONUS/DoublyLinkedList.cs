using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public int Count { get; set; }
        public LinkedListNode Head { get; set; }
        public LinkedListNode Tail { get; set; }

        public bool IsEmpty => this.Count == 0;


        public void AddFirst(T value)
        {
            if (this.IsEmpty)
            {
                this.Head = this.Tail = new LinkedListNode(value);
            }
            else
            {
                var previousHead = this.Head;
                var newNode = new LinkedListNode(value);
                previousHead.Previous = newNode;
                newNode.Next = previousHead;
                this.Head = newNode;

            }
            this.Count++;
        }
        public void AddLast(T value)
        {
            if (this.IsEmpty)
            {
                this.Head = this.Tail = new LinkedListNode(value);
            }
            else
            {
                var previousTail = this.Tail;
                var newNode = new LinkedListNode(value);
                newNode.Previous = previousTail;
                previousTail.Next = newNode;
                this.Tail = newNode;
            }
            this.Count++;

        }
        public T RemoveFirst()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }
            var removedHead = this.Head;
            var removedHeadValue = removedHead.Value;
            var nextHead = removedHead.Next;

            if (nextHead == null)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                nextHead.Previous = null;
                removedHead.Next = null;
                this.Head = nextHead;
            }
            this.Count--;

            return removedHeadValue;
        }
        public T RemoveLast()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }
            var removedTail = this.Tail;
            var removedTailValue = removedTail.Value;
            var nextTail = removedTail.Previous;
            if (nextTail == null)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                removedTail.Previous = null;
                nextTail.Next = null;
                this.Tail = nextTail;
            }
            this.Count--;
            return removedTailValue;
        }
        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            this.ForEach(n => list.Add(n));
            return list;
        }
        public T[] ToArray()
        {
            var array = new T[this.Count];
            int counter = 0;

            var currNode = this.Head;
            while (currNode != null)
            {
                array[counter] = currNode.Value;
                counter++;
                currNode = currNode.Next;
            }

            return array;
        }

        public class LinkedListNode
        {
            public LinkedListNode(T value)
            {
                Value = value;
            }
            public T Value { get; set; }
            public LinkedListNode Next { get; set; }
            public LinkedListNode Previous { get; set; }
        }
    }
}
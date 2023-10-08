namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = oldHead.Next;
            this.Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            return head.Element;
        }

        public bool Contains(T item)
        {
            var current = this.head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Element, item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                {
                    yield return current.Element;
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
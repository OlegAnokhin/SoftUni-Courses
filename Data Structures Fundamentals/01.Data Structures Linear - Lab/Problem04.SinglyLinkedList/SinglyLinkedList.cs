namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            var node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = oldHead.Next;

            this.Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            if (this.head.Next == null)
            {
                T value = this.head.Element;
                this.head = null;
                this.Count--;
                return value;
            }
            
            var current = this.head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            var lastValue = current.Next.Element;
            current.Next = null;
            this.Count--;
            return lastValue;
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
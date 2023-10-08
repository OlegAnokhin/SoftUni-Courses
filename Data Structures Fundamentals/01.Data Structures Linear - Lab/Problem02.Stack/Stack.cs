namespace Problem02.Stack
{
    using System;
    using System.Data;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var node = new Node(item, this.top);
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var oldTop = this.top;
            this.top = oldTop.Next;
            this.Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            var current = this.top;

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
            var current = this.top;

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
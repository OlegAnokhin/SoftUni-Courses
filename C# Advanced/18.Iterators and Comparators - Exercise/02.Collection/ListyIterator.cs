using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace ListyIterator
{
    public class ListyIterator <T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currIndex;

        public ListyIterator(params T[] data)
        {
            collection = new List<T>(data);
            currIndex = 0;

        }


        public bool HasNext() => currIndex < collection.Count-1;
        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                currIndex++;
            }
            return canMove;
        }
        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine($"{collection[currIndex]}");
        }
        public void PrintAll() => Console.WriteLine(string.Join(" ", collection));
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in collection)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

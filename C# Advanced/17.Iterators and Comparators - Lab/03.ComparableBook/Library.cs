using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        //public IEnumerator<Book> GetEnumerator()
        //{
        //    this.books.Sort();
        //    for (int i = 0; i < this.books.Count; i++)
        //    {
        //        yield return this.books[i];
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}


        public IEnumerator<Book> GetEnumerator()
        {
            this.books.Sort();
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int position;
            public LibraryIterator(List<Book> books)

            {
                this.books = books;
                Reset();
            }

            public Book Current => this.books[position];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.position++;
                return position < books.Count;
            }

            public void Reset()
            {
                this.position = -1;
            }
        }
    }
}

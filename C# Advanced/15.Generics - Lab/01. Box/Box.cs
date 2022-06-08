using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
     public class Box<T>
    {
        public List<T> data;
        public Box()
        {
            this.data = new List<T>();
        }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add (T item)
        {
            this.data.Add(item);
        }
        public T Remove()
        {
            var lastElement = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return lastElement;
        }
    }
}

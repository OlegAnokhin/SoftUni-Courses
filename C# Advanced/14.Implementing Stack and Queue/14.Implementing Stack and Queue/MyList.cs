using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _14.Implementing_Stack_and_Queue
{
    public class MyList
    {
        private int capacity;
        private int[] data;
        public MyList()
            : this(4)
        {

        }
        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }

        public void Add(int number)
        {
            CheckIfResizeIsNeeded();
            this.data[this.Count] = number;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
         this.ValidateIndex(index);
            var result = this.data[index];
            for (int i = index+1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }
            this.Count--;
            return result;
        }
        public void Insert(int index, int element)
        {
            this.ValidateIndex(index);
            this.Count++;
            CheckIfResizeIsNeeded();
            this.ShiftRight(index);
            this.data[index] = element;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);
            var firstValue = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = firstValue;
        }
        public void Clear()
        {
            this.Count = 0;
            this.data = new int[this.capacity];
        }

        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count -1 ; i++)
            {
                this.data[i] = this.data[i + 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return;
            }
            var message = this.Count == 0
                ? "This list is empty"
                : $"This list has {this.Count} elements and it`s zero-based " +
                $"and you are trying access {index}";
            throw new ArgumentException($"Index out of range. {message}");
        }
        private void Resize() => this.data = ChangeArrayLenght("*");

        private void Shrink() => this.data = ChangeArrayLenght("/");

        private int[] ChangeArrayLenght(string operation)
        {
            var currOperation = operation == "*" ? this.data.Length * 2
                : this.data.Length / 2;

            var newCapacity = currOperation;
            var newData = new int[newCapacity];
            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }
            this.data = newData;

            return newData;
        }
    }
}

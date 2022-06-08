using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public static bool AreEqual(T left, T right)
        {
            bool result = left.Equals(right);
            return result;
        }
    }
}

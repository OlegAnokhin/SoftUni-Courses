using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstElement, TSecond secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }
        public TFirst FirstElement { get; set; }
        public TSecond SecondElement { get; set; }
        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement}";
        }
    }
}

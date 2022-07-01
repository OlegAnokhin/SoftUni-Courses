using System;
using System.Text;
using System.Collections.Generic;

namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams) 
            : base(name, price)
        {
            this.Grams = Grams;
        }
        public double Grams { get; set; }
    }
}

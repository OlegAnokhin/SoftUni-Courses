using System;
using System.Text;
using System.Collections.Generic;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }
        public double Milliliters { get; set; }
    }
}

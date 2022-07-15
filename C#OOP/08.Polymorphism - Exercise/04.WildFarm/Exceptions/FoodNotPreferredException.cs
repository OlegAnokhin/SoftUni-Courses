namespace _04.WildFarm.Exceptions
{
using System;
using System.Collections.Generic;
using System.Text;

    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string message)
            : base(message)
        {
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random random;
        public RandomList()
        {
            this.random = new Random();
        }
        public string RemoveRandomElement()
        {
            int index = random.Next(0, this.Count);
            //if (index <= 0)
            //{
            //    return null;
            //}
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    }
}

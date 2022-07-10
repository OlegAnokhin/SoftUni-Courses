namespace _06.FoodShortage.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using _06.FoodShortage.Interfaces;

    public class Rebel : IBuyer
    {
        //private string group;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }
        public string Group { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}

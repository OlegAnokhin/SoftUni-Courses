namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Topping
    {
        private string type;
        private double weight;
        private double calories;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double Calories
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        private double CalculateCalories()
        {
            double totalCalories = this.weight * 2;
            switch (this.type.ToLower())
            {
                case "meat":
                    totalCalories *= 1.2;
                    break;
                case "veggies":
                    totalCalories *= 0.8;
                    break;
                case "cheese":
                    totalCalories *= 1.1;
                    break;
                case "sauce":
                    totalCalories *= 0.9;
                    break;
            }
            return totalCalories;
        }
    }
}
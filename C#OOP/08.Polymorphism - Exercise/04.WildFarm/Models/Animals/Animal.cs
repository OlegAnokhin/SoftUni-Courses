using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public string Name { get;}
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        protected abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        protected abstract double WeightMultiplier { get; }
        public abstract string ProduceSound();
        public virtual void Eat(Food food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {

            }
        }
    }
}

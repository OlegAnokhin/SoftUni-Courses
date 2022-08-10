using Gym.Models.Equipment.Contracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;
        public Equipment(double weight, decimal price)
        {
            this.weight = weight;
            this.price = price;
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                this.weight = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value;
            }
        }
    }
}

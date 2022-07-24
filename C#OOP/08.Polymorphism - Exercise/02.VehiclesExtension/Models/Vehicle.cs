namespace _02.VehiclesExtension
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumpion;
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumpion, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumpion = fuelConsumpion;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                Validator.CheckPositiveNumber(value);
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumpion
        {
            get
            {
                return this.fuelConsumpion;
            }
            set
            {
                this.fuelConsumpion = value;
            }
        }
        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                Validator.CheckPositiveNumber(value);
                this.tankCapacity = value;
            }
        }
        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
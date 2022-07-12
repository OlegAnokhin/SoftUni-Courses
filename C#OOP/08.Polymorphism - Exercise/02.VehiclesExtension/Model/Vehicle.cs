namespace _01.Vehicles.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using _01.Vehicles.Model.Intervaces;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumpion;
        public Vehicle(double fuelQuantity, double fuelConsumpion)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumpion = fuelConsumpion;
        }
        public double FuelQuantity 
        { 
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumpion
        {
            get
            {
                return this.fuelConsumpion;
            }
            protected set
            {
                this.fuelConsumpion = value;
            }
        }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumpion;
            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            this.fuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
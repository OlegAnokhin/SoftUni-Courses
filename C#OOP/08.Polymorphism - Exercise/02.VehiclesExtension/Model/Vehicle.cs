namespace _01.Vehicles.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using _01.Vehicles.Model.Intervaces;
    using Core;
    using _02.VehiclesExtension.Model;

    public abstract class Vehicle : IVehicle
    {
        public bool ItsEmpty = false;
        private double fuelQuantity;
        private double fuelConsumpion;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumpion, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumpion = fuelConsumpion;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (this.tankCapacity < this.fuelQuantity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
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
        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                this.tankCapacity = value;
            }
        }
        public string DriveEmpty(double distance)
        {
            ItsEmpty = true;
            double fuelNeeded = distance * this.fuelConsumpion;
            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            this.fuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
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
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (this.tankCapacity < this.fuelQuantity + liters)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.fuelQuantity += liters;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
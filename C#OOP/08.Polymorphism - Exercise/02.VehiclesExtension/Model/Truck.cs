﻿namespace _01.Vehicles.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoeffiecient = 0.95;
        public Truck(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
        }
        public override double FuelConsumpion
        {
            get
            {
                return base.FuelConsumpion;
            }
            protected set
            {
                base.FuelConsumpion = value + TruckFuelConsumptionIncrement;
            }
        }
        public override void Refuel(double liters)
        {
            if (liters > TankCapacity)
            {
                base.Refuel(liters);
            }
            else
            {
                base.Refuel(liters * RefuelCoeffiecient);
            }
        }
    }
}

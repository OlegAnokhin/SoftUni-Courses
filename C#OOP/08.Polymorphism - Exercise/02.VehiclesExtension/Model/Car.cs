namespace _01.Vehicles.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;
        public Car(double fuelQuantity, double fuelConsumpion, double tankCapacity) 
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
                base.FuelConsumpion = value + CarFuelConsumptionIncrement;
            }
        }
    }
}

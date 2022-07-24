namespace _02.VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car : Vehicle
    {
        private const double CarFuelConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumpion, double tankCapacity) 
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {

        }
        public override void Drive(double distance)
        {
            double neededFuel = distance * (base.FuelConsumpion + CarFuelConsumption);
            if (neededFuel <= base.FuelQuantity)
            {
                base.FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double fuelWithRefuel = base.FuelQuantity + liters;
                if (fuelWithRefuel > base.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += liters;
                }
            }
        }
    }
}

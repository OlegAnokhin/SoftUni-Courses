namespace _02.VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumption = 1.6;
        private const double RefuelCoeffiecient = 0.95;
        public Truck(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
        }
        public override void Drive(double distance)
        {
            double neededFuel = distance * (base.FuelConsumpion + TruckFuelConsumption);
            if (neededFuel <= base.FuelQuantity)
            {
                base.FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
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
                double fuelWithRefuel = base.FuelQuantity + (liters * RefuelCoeffiecient);
                if (fuelWithRefuel > base.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += (liters * RefuelCoeffiecient);
                }
            }
        }
    }
}
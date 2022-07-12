namespace _01.Vehicles.Factories
{
    using _01.Vehicles.Factories.Interfaces;
    using _01.Vehicles.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle= new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }
            return vehicle;
        }
    }
}

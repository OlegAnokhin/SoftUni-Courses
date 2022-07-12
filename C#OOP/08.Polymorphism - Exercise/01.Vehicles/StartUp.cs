namespace _01.Vehicles
{
    using System;
    using _01.Vehicles.Core;
    using _01.Vehicles.Model;
    using _01.Vehicles.Factories;
    using _01.Vehicles.Factories.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {          
            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory
                .CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = vehicleFactory
                .CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));
            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}

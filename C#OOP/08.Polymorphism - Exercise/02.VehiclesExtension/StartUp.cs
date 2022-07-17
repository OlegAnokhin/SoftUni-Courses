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
            string[] busData = Console.ReadLine().Split();
            

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory
                .CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            Vehicle truck = vehicleFactory
                .CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            Vehicle bus = vehicleFactory
                .CreateVehicle(busData[0], double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}


//Car 30 0.04 70
//Truck 100 0.5 300
//Bus 40 0.3 150
//8
//Refuel Car -10
//Refuel Truck 0
//Refuel Car 10
//Refuel Car 300
//Drive Bus 10
//Refuel Bus 1000
//DriveEmpty Bus 100
//Refuel Truck 1000
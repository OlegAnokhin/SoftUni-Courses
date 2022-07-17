namespace _01.Vehicles.Core
{
    using System;
    using System.Text;
    using _01.Vehicles.Model;
    using System.Collections.Generic;
    using _02.VehiclesExtension.Model;

    public class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;
        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                string cmdType = cmdArg[0];
                string vehicleType = cmdArg[1];
                double cmdParam = double.Parse(cmdArg[2]);

                if (cmdType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.car.Drive(cmdParam));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(cmdParam));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(this.bus.Drive(cmdParam));
                    }
                }
                else if (cmdType == "DriveEmpty")
                {
                    Console.WriteLine(this.bus.DriveEmpty(cmdParam));
                }
                else if (cmdType == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        this.car.Refuel(cmdParam);
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.truck.Refuel(cmdParam);
                    }
                    else if (vehicleType == "Bus")
                    {
                        this.bus.Refuel(cmdParam);
                    }
                }
            }
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}

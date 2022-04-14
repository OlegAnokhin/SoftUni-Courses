using System;
using System.Collections.Generic;
using System.Linq;

namespace _007._Vehicle_Catalogue
{

    class Truck
    {
        public Truck(string brand, string model, int wheit)
        {
            Brand = brand;
            Model = model;
            Wheit = wheit;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Wheit { get; set; }
    }

    class Car
    {
        public Car(string brand, string model, int horsepower)
        {
            Brand=brand;
            Model = model;
            HorsePower = horsepower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalog
    {
        public Catalog()
        {
            this.Truck = new List<Truck>();
            this.Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Truck { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalogObjects = new Catalog();
            
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] splitParams = command.Split('/',
                    StringSplitOptions.RemoveEmptyEntries);

                string type = splitParams[0];
                string brand = splitParams[1];
                string model = splitParams[2];
                int finalParam = int.Parse(splitParams[3]);

                if (type == "Car")
                {
                    Car newCar = new Car(brand, model, finalParam);
                    catalogObjects.Cars.Add(newCar);
                }
                if (type == "Truck")
                {
                    Truck newTruck = new Truck(brand, model, finalParam);
                    catalogObjects.Truck.Add(newTruck);
                }

                command = Console.ReadLine();
            }

            if (catalogObjects.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                List<Car> orderedCars = catalogObjects.Cars.OrderBy(car => car.Brand).ToList();
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogObjects.Truck.Count > 0)
            {
                Console.WriteLine("Trucks:");
                List<Truck> orderedTrucks = catalogObjects.Truck.OrderBy(truck => truck.Brand)
                    .ToList();

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Wheit}kg");
                }
            }
        }
    }
}

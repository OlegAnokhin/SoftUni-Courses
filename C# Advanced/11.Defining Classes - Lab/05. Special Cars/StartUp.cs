using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Tire[]> listOftires = new List<Tire[]>();
            List<Engine> listOfEngines = new List<Engine>();
            List<Car> listOfCars = new List<Car>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tires = input.Split();
                Tire[] currTires = new Tire[4]
                {
                 new Tire(int.Parse(tires[0]), double.Parse(tires[1])),
                 new Tire(int.Parse(tires[2]), double.Parse(tires[3])),
                 new Tire(int.Parse(tires[4]), double.Parse(tires[5])),
                 new Tire(int.Parse(tires[6]), double.Parse(tires[7]))
            };
                listOftires.Add(currTires);
            }
            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] engines = input.Split().Select(double.Parse).ToArray();

                int horsePower = (int)(engines[0]);
                double cubic = engines[1];
                Engine currEngine = new Engine(horsePower, cubic);
                listOfEngines.Add(currEngine);
            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] spCars = input.Split();
                string Name = spCars[0];
                string model = spCars[1];
                int year = int.Parse(spCars[2]);
                double fuelQuantity = double.Parse(spCars[3]);
                double fuelConsumption = double.Parse(spCars[4]);
                int engineIndex = int.Parse(spCars[5]);
                int tiresIndex = int.Parse(spCars[6]);
                Car currCar = new Car(Name, model, year, fuelQuantity, fuelConsumption, listOfEngines[engineIndex], listOftires[tiresIndex]);
                listOfCars.Add(currCar);
            }
            string result = SpecialCars(listOfCars);
            Console.WriteLine(result);
        }
        public static string SpecialCars(List<Car> cars)
        {
            List<Car> specialCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();
            StringBuilder result = new StringBuilder();
            foreach (var car in specialCars)
            {
                car.Drive(20);
                result.AppendLine($"Make: {car.Make}");
                result.AppendLine($"Model: {car.Model}");
                result.AppendLine($"Year: {car.Year}");
                result.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                result.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }
            return result.ToString();
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Need_for_Speed_III
{
    class Car
    {
        public int Milage { get; set; }
        public int Fuel { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                cars.Add(input[0], new Car()
                {
                    Milage = int.Parse(input[1]),
                    Fuel = int.Parse(input[2])
                });
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] splitCommand = command.Split(" : ");
                if (splitCommand[0] == "Drive")
                {
                    string car = splitCommand[1];
                    int distance = int.Parse(splitCommand[2]);
                    int fuel = int.Parse(splitCommand[3]);
                    Car carData = cars[car];
                    if (carData.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Milage += distance;
                        cars[car].Fuel -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[car].Milage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                    }
                }
                if (splitCommand[0] == "Refuel")
                {
                    string car = splitCommand[1];
                    int fuel = int.Parse(splitCommand[2]);
                    int oldFuel = cars[car].Fuel;
                    cars[car].Fuel += fuel;
                    if (cars[car].Fuel > 75)
                    {
                        cars[car].Fuel = 75;
                        Console.WriteLine($"{car} refueled with {75 - oldFuel} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else if (splitCommand[0] == "Revert")
                {
                    string car = splitCommand[1];
                    int distance = int.Parse(splitCommand[2]);
                    cars[car].Milage -= distance;
                    if (cars[car].Milage < 10000)
                    {
                        cars[car].Milage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {distance} kilometers");
                    }
                }
                command = Console.ReadLine();
            }
            cars = cars.OrderByDescending(c => c.Value.Fuel)
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Milage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}

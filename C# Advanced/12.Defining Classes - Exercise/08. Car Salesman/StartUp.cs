using System;
using System.Collections.Generic;

namespace CarSalesman
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> enginesList = new Dictionary<string, Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] engineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineInput[0];
                int power = int.Parse(engineInput[1]);

                Engine engine = new Engine(engineModel, power);
                if (engineInput.Length == 3)
                {
                    if (char.IsDigit(engineInput[2][0]))
                    {
                        int displacement = int.Parse(engineInput[2]);
                        engine = new Engine(engineModel, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineInput[2];
                        engine = new Engine(engineModel, power, efficiency);
                    }
                }
                else if (engineInput.Length == 4)
                {
                    int displacement = int.Parse(engineInput[2]);
                    string efficiency = engineInput[3];
                    engine = new Engine(engineModel, power, displacement, efficiency);
                }
                else
                {
                    engine = new Engine(engineModel, power);
                }
                enginesList.Add(engineModel, engine);
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInput[0];
                string carEngine = carInput[1];
                Engine engine = enginesList[carEngine];
                if (carInput.Length == 3)
                {
                    if (char.IsDigit(carInput[2][0]))
                    {
                        int carWeight = int.Parse(carInput[2]);
                        Car car = new Car(carModel, engine, carWeight);
                        cars.Add(car);
                    }
                    else
                    {
                        string carColor = carInput[2];
                        Car car = new Car(carModel, engine, carColor);
                        cars.Add(car);
                    }
                }
                else if (carInput.Length == 4)
                {
                    int carWeight = int.Parse(carInput[2]);
                    string carColor = carInput[3];
                    Car car = new Car(carModel, engine, carWeight, carColor);
                    cars.Add(car);
                }
                else
                {
                    Car car = new Car(carModel, engine);
                    cars.Add(car);
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}

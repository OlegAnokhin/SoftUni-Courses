using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int a = 0; a < n; a++)
            {
                var input = Console.ReadLine().Split(" ", 6).ToArray();
                var engine = new Engine();
                var cargo = new Cargo();
                var tires = new List<Tire>();
                string model = input[0];
                engine.Speed = int.Parse(input[1]);
                engine.Power = int.Parse(input[2]);
                cargo.Weight = int.Parse(input[3]);
                cargo.Type = input[4];
                var tiresArr = input[5].Split(" ").ToArray();
                for (int b = 0; b < tiresArr.Length; b+=2)
                {
                    var tire = new Tire();
                    tire.Pressure = double.Parse(tiresArr[b]);
                    tire.Age = int.Parse(tiresArr[b +1]);
                    tires.Add(tire);
                }
                var car = new Car(model,engine,cargo,tires.ToArray());
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    string model = "";
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1 && car.Model != model)
                        {
                            model = car.Model;
                            Console.WriteLine($"{car.Model}");
                        }
                    }
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in cars)
                {
                    if (car.Engine.Power > 250)
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }
        }
    }
}

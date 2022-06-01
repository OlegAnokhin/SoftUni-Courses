using CarManufacturer;
using System;

public class StartUp
{
    public static void Main()
    {
        Car car = new Car();
        car.Year = 2000;
        car.Make = "BMW";
        car.Model = "320D";
        car.FuelQuantity = 50;
        car.FuelConsumption = 0.04;

        Console.WriteLine(car.WhoAmI());
        Console.WriteLine();

        car.Drive(700);
        Console.WriteLine(car.WhoAmI());
        Console.WriteLine();

        car.Drive(50);
        Console.WriteLine(car.WhoAmI());
        Console.WriteLine();

        Engine lamboEngine = new Engine(530 , 6300);
        Tire[] lamboTires = new Tire[]
        {
            new Tire (1, 2.5),
            new Tire (1, 2.1),
            new Tire (2, 0.5),
            new Tire (2, 2.3),
        };
        Car lambo = new Car("Lambo", "Urus", 2010, 250, 9, lamboEngine, lamboTires);
        lambo.Drive(5);
        Console.WriteLine(lambo.WhoAmI());
        Console.WriteLine();

    }
}

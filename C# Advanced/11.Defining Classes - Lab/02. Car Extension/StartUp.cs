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
    }
}

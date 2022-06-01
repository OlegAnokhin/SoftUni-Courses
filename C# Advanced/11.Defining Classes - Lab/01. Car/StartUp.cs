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

            Console.WriteLine($"Make: {car.Make} Model: {car.Model} Year: {car.Year}");
        }
    }

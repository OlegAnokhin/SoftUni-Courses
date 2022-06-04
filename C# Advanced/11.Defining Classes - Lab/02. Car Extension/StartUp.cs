using CarManufacturer;
using System;

namespace CarManufacturer
{

    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car();
            car.Make = "BMW";
            car.Model = "320D";
            car.Year = 2000;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(2000);

            Console.WriteLine(car.WhoAmI());
        }
    }
}

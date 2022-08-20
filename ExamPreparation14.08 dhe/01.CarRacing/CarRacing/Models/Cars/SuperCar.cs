using System;
using System.Text;
using System.Collections.Generic;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double defFuelAvailable = 80.00;
        private const double defFuelConsumptionPerRace = 10.00;

        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, defFuelAvailable, defFuelConsumptionPerRace)
        {
        }
    }
}
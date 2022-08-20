using System;
using System.Text;
using System.Collections.Generic;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double defFuelAvailable = 65.00;
        private const double defFuelConsumptionPerRace = 7.50;
        public TunedCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, defFuelAvailable, defFuelConsumptionPerRace)
        {
        }
        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round((double)HorsePower - (double)HorsePower * 0.03);
        }
    }
}
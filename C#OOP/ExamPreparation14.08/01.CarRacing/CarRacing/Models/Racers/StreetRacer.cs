using System;
using System.Text;
using System.Collections.Generic;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int drivingExperience = 10;
        private const string racinBehavior = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, racinBehavior, drivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
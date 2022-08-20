using CarRacing.Models.Cars.Contracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int drivingExperience = 30;
        private const string racinBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, racinBehavior, drivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
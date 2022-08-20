using System;
using System.Text;
using System.Collections.Generic;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double defOxygen = 90.00;
        public Meteorologist(string name) 
            : base(name, defOxygen)
        {
        }
    }
}
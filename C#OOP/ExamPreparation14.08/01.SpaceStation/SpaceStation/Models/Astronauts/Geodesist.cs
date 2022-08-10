using System;
using System.Text;
using System.Collections.Generic;

namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double defOxygen = 50.00;
        public Geodesist(string name) 
            : base(name, defOxygen)
        {
        }
    }
}
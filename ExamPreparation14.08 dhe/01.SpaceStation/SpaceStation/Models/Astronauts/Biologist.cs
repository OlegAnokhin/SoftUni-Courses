using System;
using System.Text;
using System.Collections.Generic;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double defOxygen = 70.00;
        public Biologist(string name) 
            : base(name, defOxygen)
        {
        }
        public override bool CanBreath => Oxygen >= 5.00;
        public override void Breath()
        {
            if (Oxygen - 5 <= 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 5.00;
            }
        }
    }
}
using System;
using System.Text;
using System.Collections.Generic;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double defCost = 11;
        public SpaceForces() 
            : base(defCost)
        {
        }
    }
}
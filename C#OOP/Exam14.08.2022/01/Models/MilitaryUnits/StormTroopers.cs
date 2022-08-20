using System;
using System.Text;
using System.Collections.Generic;

namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        private const double defCost = 2.5;
        public StormTroopers() 
            : base(defCost)
        {
        }
    }
}
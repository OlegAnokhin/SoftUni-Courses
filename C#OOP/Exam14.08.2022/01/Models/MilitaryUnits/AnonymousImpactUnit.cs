using System;
using System.Text;
using System.Collections.Generic;

namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double defCost = 30;
        public AnonymousImpactUnit() 
            : base(defCost)
        {
        }
    }
}
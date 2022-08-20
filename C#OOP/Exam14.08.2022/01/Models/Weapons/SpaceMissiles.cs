using System;
using System.Text;
using System.Collections.Generic;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double defPrice = 8.75;
        public SpaceMissiles(int destructionLevel) 
            : base(destructionLevel, defPrice)
        {
        }
    }
}
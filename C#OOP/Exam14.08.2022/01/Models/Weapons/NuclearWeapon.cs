using System;
using System.Text;
using System.Collections.Generic;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double defPrice = 15;
        public NuclearWeapon(int destructionLevel) 
            : base(destructionLevel, defPrice)
        {
        }
    }
}
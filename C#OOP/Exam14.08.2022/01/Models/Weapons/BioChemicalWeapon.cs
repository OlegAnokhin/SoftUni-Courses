using System;
using System.Text;
using System.Collections.Generic;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double defPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel) 
            : base(destructionLevel, defPrice)
        {
        }
    }
}
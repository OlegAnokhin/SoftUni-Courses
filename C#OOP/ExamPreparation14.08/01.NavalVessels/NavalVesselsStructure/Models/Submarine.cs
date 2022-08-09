namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;
        private const double defaultArmorThicknes = 200.00;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, defaultArmorThicknes)
        {
            
        }
        public bool SubmergeMode => throw new NotImplementedException();        
        public void ToggleSubmergeMode()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
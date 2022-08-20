using NavalVessels.Models.Contracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        private const double defaultArmorThickness = 200.00;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, defaultArmorThickness)
        {
            SubmergeMode = false;
        }
        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set {submergeMode = value;}
        }
        public override void RepairVessel()
        {
            if (ArmorThickness < defaultArmorThickness)
            {
                ArmorThickness = defaultArmorThickness;
            }
        }
        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == true)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40.00;
                Speed += 4.00;
            }
            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40.00;
                Speed -= 4.00;
            }
        }
        public override string ToString()
        {
            var submergeMode = SubmergeMode == true ? " *Submerge mode: ON" : " *Submerge mode: OFF";
            return base.ToString() + Environment.NewLine + submergeMode;
        }
    }
}
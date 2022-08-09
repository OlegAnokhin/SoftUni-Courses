using NavalVessels.Models.Contracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        private const double defaultArmorThickness = 300.00;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, defaultArmorThickness)
        {
            SonarMode = false;
        }
        public bool SonarMode
        {
            get {return sonarMode;}
            private set {sonarMode = value;}
        }
        public override void RepairVessel()
        {
            if (ArmorThickness < defaultArmorThickness)
            {
                ArmorThickness = defaultArmorThickness;
            }
        }
        public void ToggleSonarMode()
        {
            if (SonarMode == true)
            {
                SonarMode = false;
                MainWeaponCaliber -= 40.00;
                Speed += 5.00;
            }
            else
            {
                SonarMode = true;
                MainWeaponCaliber += 40.00;
                Speed -= 5.00;
            }
        }
        public override string ToString()
        {
            var sonarMode = SonarMode == true ? " *Sonar mode: ON" : " *Sonar mode: OFF";
            return base.ToString() + Environment.NewLine + sonarMode;
        }
    }
}
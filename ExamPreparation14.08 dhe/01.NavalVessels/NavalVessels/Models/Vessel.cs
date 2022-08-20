using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Text;
using System.Collections.Generic;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private readonly ICollection<string> targets;
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
            captain = null;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        (ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }
        public ICaptain Captain
        {
            get
            {
                return captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException
                        (ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            set { mainWeaponCaliber = value; }
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException
                    (ExceptionMessages.InvalidTarget);
            }
            if (target.ArmorThickness - MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0.00;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }
            if (!Targets.Contains(target.Name))
            {
                Targets.Add(target.Name);
            }
        }
        public abstract void RepairVessel();
        public override string ToString()
        {
            var sb = new StringBuilder();
            var targetCount = Targets.Count == 0 ? "None" : String.Join(", ", Targets);
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine($" *Targets: {targetCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
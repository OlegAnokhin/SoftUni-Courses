using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private ICollection<IMilitaryUnit> units;
        private ICollection<IWeapon> weapons;
        private string name;
        private double budget;
        private double militaryPower;
        public Planet(string name, double budget)
        {
            units = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
            Name = name;
            Budget = budget;
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
                    throw new ArgumentException
                        (ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }
        public double Budget
        {
            get
            {
                return budget;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }
        public double MilitaryPower => MilitaryPowerAmount();

        private double MilitaryPowerAmount()
        {
            double totalAmount = this.Army.Sum(u => u.EnduranceLevel) + this.Weapons.Sum(w => w.DestructionLevel);
            if (Army.Any(a => a.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount += totalAmount * 0.3;
            }
            if (Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount += totalAmount * 0.45;
            }
            return Math.Round(totalAmount, 3);
        }
        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)units;
        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons;
        public void AddUnit(IMilitaryUnit unit)
        {
            units.Add(unit);
        }
        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }
        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
               unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }
        public void Profit(double amount)
        {
            Budget += amount;
        }
        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            var unitExist = units.Count == 0 ? "No units" 
                : string.Join(", ", units.Select(n => n.GetType().Name)); 
            var weaponExist = weapons.Count == 0 ? "No weapons" 
                : string.Join(", ", weapons.Select(n => n.GetType().Name));
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {unitExist}");
            sb.AppendLine($"--Combat equipment: {weaponExist}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }
    }
}
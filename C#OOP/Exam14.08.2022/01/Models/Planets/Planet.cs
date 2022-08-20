using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private ICollection<IMilitaryUnit> units;
        private ICollection<IWeapon> weapons;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            units = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
        public double Budget
        {
            get
            {
                return this.budget;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }
        public double MilitaryPower => MilitaryPowerValue();
        private double MilitaryPowerValue()
        {
            double total = units.Sum(e => e.EnduranceLevel) + weapons.Sum(e => e.DestructionLevel);
            if (units.Any(a => a.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                total += total * 0.3;
            }
            if (weapons.Any(a => a.GetType().Name == nameof(NuclearWeapon)))
            {
                total += total * 0.45;
            }
            return Math.Round(total, 3);
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
            foreach (IMilitaryUnit unit in units)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }
        public void Profit(double amount)
        {
            this.Budget += amount;
        }
        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            var actualforces = units.Count == 0 ? "No units" : string.Join(", ", units.Select(n => n.GetType().Name));
            var actualweapons = weapons.Count == 0 ? "No weapons" : string.Join(", ", weapons.Select(n => n.GetType().Name));
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {actualforces}");
            sb.AppendLine($"--Combat equipment: {actualweapons}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().Trim();
        }
    }
}
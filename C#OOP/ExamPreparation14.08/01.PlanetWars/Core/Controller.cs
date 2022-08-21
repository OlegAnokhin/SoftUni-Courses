using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget); 
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit currUnit = null;
            var currPlanet = planets.FindByName(planetName);
            if (currPlanet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (currPlanet.Army.Any(t => t.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            if (unitTypeName == nameof(StormTroopers))
            {
                currUnit = new StormTroopers();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                currUnit = new SpaceForces();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                currUnit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            currPlanet.Spend(currUnit.Cost);
            currPlanet.AddUnit(currUnit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IWeapon currWeapon = null;
            var currPlanet = planets.FindByName(planetName);
            if (currPlanet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (currPlanet.Weapons.Any(t => t.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            if (weaponTypeName == nameof(SpaceMissiles))
            {
                currWeapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                currWeapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                currWeapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            currPlanet.Spend(currWeapon.Price);
            currPlanet.AddWeapon(currWeapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            var currPlanet = planets.FindByName(planetName);
            if (currPlanet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (currPlanet.Army.Count <= 0)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.NoUnitsFound));
            }
            currPlanet.Spend(1.25);
            currPlanet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planets.FindByName(planetOne);
            var defender = planets.FindByName(planetTwo);
            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                attacker.Spend(attacker.Budget / 2);
                attacker.Profit(defender.Budget / 2);
                attacker.Profit(defender.Army.Sum(c => c.Cost) + defender.Weapons.Sum(p => p.Price));
                planets.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (attacker.MilitaryPower < defender.MilitaryPower)
            {
                defender.Spend(defender.Budget / 2);
                defender.Profit(attacker.Budget / 2);
                defender.Profit(attacker.Army.Sum(c => c.Cost) + attacker.Weapons.Sum(p => p.Price));
                planets.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else if (attacker.MilitaryPower == defender.MilitaryPower)
            {
                if (attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                    defender.Weapons.Any(w => w.GetType().Name != nameof(NuclearWeapon)))
                {
                    attacker.Spend(attacker.Budget / 2);
                    attacker.Profit(defender.Budget / 2);
                    attacker.Profit(defender.Army.Sum(c => c.Cost) + defender.Weapons.Sum(p => p.Price));
                    planets.RemoveItem(planetTwo);
                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (attacker.Weapons.Any(w => w.GetType().Name != nameof(NuclearWeapon)) &&
                         defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    defender.Spend(defender.Budget / 2);
                    defender.Profit(attacker.Budget / 2);
                    defender.Profit(attacker.Army.Sum(c => c.Cost) + attacker.Weapons.Sum(p => p.Price));
                    planets.RemoveItem(planetTwo);
                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else if (attacker.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) &&
                         defender.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }
                else if (attacker.Weapons.Any(w => w.GetType().Name != nameof(NuclearWeapon)) &&
                         defender.Weapons.Any(w => w.GetType().Name != nameof(NuclearWeapon)))
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }
            }
            return string.Empty;
        }
        public string ForcesReport()
        {
            var sb = new StringBuilder();
            var order = planets.Models.OrderByDescending(m => m.MilitaryPower)
                                      .ThenBy(n => n.Name);
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in order)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
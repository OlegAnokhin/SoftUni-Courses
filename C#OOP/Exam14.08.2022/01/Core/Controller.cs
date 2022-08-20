using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using PlanetWars.Utilities.Messages;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        private UnitRepository units;
        private WeaponRepository weapons;
        public Controller()
        {
            planets = new PlanetRepository();
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = planets.Models.FirstOrDefault(n => n.Name == name);
            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            var currPlanet = new Planet(name, budget);
            planets.AddItem(currPlanet);
            return string.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit currUnit = null;

            var PL = planets.FindByName(planetName);
            if (PL == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != nameof(StormTroopers) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(AnonymousImpactUnit))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (PL.Army.Any(u => u.GetType().Name == unitTypeName))
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

            PL.Spend(currUnit.Cost);
            PL.AddUnit(currUnit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var PL = planets.FindByName(planetName);
            var weapon = weapons.FindByName(weaponTypeName);
            if (PL == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (weapons.Models.GetType().Name == weaponTypeName)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            PL.Spend(weapon.Price);
            PL.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            var PL = planets.FindByName(planetName);
            if (PL == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (PL.Army.Count <= 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoUnitsFound);
            }
            PL.Spend(1.25);
            PL.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planets.FindByName(planetOne);
            var planet2 = planets.FindByName(planetTwo);
            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) && planet2.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) ||
                planet1.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon)) && planet2.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon)))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return String.Format(OutputMessages.NoWinner);
                }
                else if (planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet1.Profit(planet2.Budget / 2);
                    planet1.Profit(planet2.Army.Sum(s => s.Cost));
                    planet1.Profit(planet2.Weapons.Sum(s => s.Price));
                    planets.RemoveItem(planetTwo);
                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    planet2.Spend(planet2.Budget / 2);
                    planet2.Profit(planet1.Budget / 2);
                    planet2.Profit(planet1.Army.Sum(s => s.Cost));
                    planet2.Profit(planet1.Weapons.Sum(s => s.Price));
                    planets.RemoveItem(planetOne);
                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                planet1.Profit(planet2.Army.Sum(s => s.Cost));
                planet1.Profit(planet2.Weapons.Sum(s => s.Price));
                planets.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                planet2.Profit(planet1.Army.Sum(s => s.Cost));
                planet2.Profit(planet1.Weapons.Sum(s => s.Price));
                planets.RemoveItem(planetOne);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
        }
        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models
                .OrderByDescending(mp => mp.MilitaryPower)
                .ThenBy(n => n.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
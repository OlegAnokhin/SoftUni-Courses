using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;
        private readonly ICollection<string> exploredPlanets;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            exploredPlanets = new List<string>();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAstronautType);
            }
            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }
        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
        public string ExplorePlanet(string planetName)
        {
            var mission = new Mission();
            var planet = planets.FindByName(planetName);
            var pickedAstronauts = astronauts.Models.Where(o => o.Oxygen > 60.00).ToList();
            if (planet == null)
            {
                return null;
            }
            if (pickedAstronauts.Count == 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAstronautCount);
            }
            mission.Explore(planet, pickedAstronauts);
            exploredPlanets.Add(planetName);
            var deadAstronauts = pickedAstronauts.Where(x => x.Oxygen == 0).Count();
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (planet.Items.Any() && astronaut.CanBreath)
                {
                    var currItem = planet.Items.First();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(currItem);
                    planet.Items.Remove(currItem);
                    if (astronaut.Oxygen == 0 || planet.Items.Count == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
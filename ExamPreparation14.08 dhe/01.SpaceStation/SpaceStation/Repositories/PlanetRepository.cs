using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)planets;

        public void Add(IPlanet model)
        {
            planets.Add(model);
        }
        public bool Remove(IPlanet model)
        {
            return planets.Remove(model);
        }
        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(n => n.Name == name);
        }
    }
}
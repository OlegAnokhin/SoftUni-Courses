using System;
using System.Text;
using System.Collections.Generic;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Models.Planets.Contracts;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)planets;
        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }
        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(x => x.Name == name);
        }
        public bool RemoveItem(string name)
        {
            var planetToRemove= planets.FirstOrDefault(x => x.Name == name);
           return planets.Remove(planetToRemove);
        }
    }
}
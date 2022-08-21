using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
        public IPlanet FindByName(string name)
        {
            var currPlanet = planets.FirstOrDefault(n => n.Name == name);
            return currPlanet;
        }
        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }
        public bool RemoveItem(string name)
        {
            return planets.Remove(planets.FirstOrDefault(p => p.Name == name));
        }
    }
}
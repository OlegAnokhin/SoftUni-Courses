using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)units;
        public IMilitaryUnit FindByName(string name)
        {
            var currUnit = units.FirstOrDefault(n => n.GetType().Name == name);
            return currUnit;
        }
        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }
        public bool RemoveItem(string name)
        {
            return units.Remove(units.FirstOrDefault(p => p.GetType().Name == name));
        }
    }
}
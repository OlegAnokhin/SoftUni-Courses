using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> militaryUnits;
        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)militaryUnits;
        public IMilitaryUnit FindByName(string name)
        {
            return Models.FirstOrDefault(n => n.GetType().Name == name);
        }
        public void AddItem(IMilitaryUnit model)
        {
            militaryUnits.Add(model);
        }
        public bool RemoveItem(string name)
        {
            return militaryUnits.Remove(Models.FirstOrDefault(n => n.GetType().Name == name));
        }
    }
}
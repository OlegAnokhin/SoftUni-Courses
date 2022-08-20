using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Models.Weapons.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)weapons;
        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(n => n.GetType().Name == name);
        }
        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }
        public bool RemoveItem(string name)
        {
            return weapons.Remove(Models.FirstOrDefault(n => n.GetType().Name == name));
        }
    }
}
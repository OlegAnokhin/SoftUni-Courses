using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

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
            var currWeapon = weapons.FirstOrDefault(n => n.GetType().Name == name);
            return currWeapon;
        }
        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }
        public bool RemoveItem(string name)
        {
            return weapons.Remove(weapons.FirstOrDefault(p => p.GetType().Name == name));
        }
    }
}
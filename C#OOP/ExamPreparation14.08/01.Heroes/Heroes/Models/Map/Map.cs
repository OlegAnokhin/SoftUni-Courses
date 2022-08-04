using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();
            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type.");
                    }
                }
            }
            var continueBattle = true;
            while (continueBattle)
            {
                var allKnightsAreDeat = true;
                var allBarbariansAreDeat = true;
                var aliveKnights = 0;
                var aliveBarbarians = 0;
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDeat = false;
                        aliveKnights++;
                        foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            var weaponDamage = knight.Weapon.DoDamage();
                                barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }
                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDeat = false;
                        aliveBarbarians++;
                        foreach (var knight in knights.Where(kn => kn.IsAlive))
                        {
                            var weaponDamage = barbarian.Weapon.DoDamage();
                            knight.TakeDamage(weaponDamage);
                        }
                    }
                }
                if (allKnightsAreDeat)
                {
                    return $"The barbarians took {barbarians.Count - aliveBarbarians} casualties but won the battle.";
                }
                if (allBarbariansAreDeat)
                {
                    return $"The knights took {knights.Count - aliveKnights} casualties but won the battle.";
                }
            }
            throw new InvalidOperationException("The map fight logic has a bug.");
        }
    }
}

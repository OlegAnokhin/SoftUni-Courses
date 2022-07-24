namespace _03.Raiding.Core
{
    using _03.Raiding.Factory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private ICollection<BaseHero> heroes;
        public Engine()
        {
            heroes = new List<BaseHero>();
        }
        public void Start()
        {
            int counter = 0;
            int n = int.Parse(Console.ReadLine());
            while (n != counter)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();
                try
                {
                    BaseHero hero = FactoryHeroes.CreateHero(typeHero, name);
                    heroes.Add(hero);
                    counter++;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            double bossPower = double.Parse(Console.ReadLine());
            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int allPower = heroes.Sum(p => p.Power);
            if (allPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
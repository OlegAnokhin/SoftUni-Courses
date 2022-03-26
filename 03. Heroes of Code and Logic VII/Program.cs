using System;
using System.Collections.Generic;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public int Healt { get; set; }
        public int ManaPoints { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                heroes.Add(input[0], new Hero()
                {
                    Healt = int.Parse(input[1]),
                    ManaPoints = int.Parse(input[2])
                });
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] splitCommand = command.Split(" - ");
                if (splitCommand[0] == "CastSpell")
                {
                    string heroName = splitCommand[1];
                    int manaNeeded = int.Parse(splitCommand[2]);
                    string spellName = splitCommand[3];

                    Hero currHero = heroes[heroName];
                    if (currHero.ManaPoints >= manaNeeded)
                    {
                        currHero.ManaPoints -= manaNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currHero.ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (splitCommand[0] == "TakeDamage")
                {
                    string heroName = splitCommand[1];
                    int damage = int.Parse(splitCommand[2]);
                    string attacker = splitCommand[3];

                    Hero currHero = heroes[heroName];
                    currHero.Healt -= damage;
                    if (currHero.Healt > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currHero.Healt} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }
                else if (splitCommand[0] == "Recharge")
                {
                    string heroName = splitCommand[1];
                    int amount = int.Parse(splitCommand[2]);

                    Hero currHero = heroes[heroName];
                    int oldMana = currHero.ManaPoints;
                    currHero.ManaPoints += amount;
                    if (currHero.ManaPoints > 200)
                    {
                        currHero.ManaPoints = 200;
                        Console.WriteLine($"{heroName} recharged for {200 - oldMana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else if (splitCommand[0] == "Heal")
                {
                    string heroName = splitCommand[1];
                    int amount = int.Parse(splitCommand[2]);
                    Hero currHero = heroes[heroName];

                    int oldHealt = currHero.Healt;
                    currHero.Healt += amount;
                    if (currHero.Healt > 100)
                    {
                        currHero.Healt = 100;
                        Console.WriteLine($"{heroName} healed for {100 - oldHealt} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.Healt}");
                Console.WriteLine($"  MP: {hero.Value.ManaPoints}"); 
            }
        }
    }
}

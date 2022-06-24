using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();
            var command = Console.ReadLine();

            while (command != "Tournament")
            {
                var input = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var trainerName = input[0];
                var pokemonName = input[1];
                var element = input[2];
                var health = int.Parse(input[3]);
                var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                if (trainer != null)
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, element, health));
                }
                else
                {
                    var newTrainer = new Trainer(trainerName);
                    newTrainer.Pokemons.Add(new Pokemon(pokemonName, element, health));
                    trainers.Add(newTrainer);
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    if (!trainers[i].Pokemons.Any(e => e.Element == command))
                    {
                        foreach (var item in trainers[i].Pokemons)
                        {
                            item.ReduceHealth();
                            if (item.Health <= 0)
                            {
                                trainers[i].Pokemons.RemoveAll(x => x.Health <= 0);
                                break;
                            }
                        }
                    }
                    else
                    {
                        trainers[i].IncreaceNumberOfBadges();
                    }
                }
                command = Console.ReadLine();
            }
            trainers.OrderByDescending(x => x.NumberOfBadges).ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.NumberOfBadges} {x.Pokemons.Count}"));
        }
    }
}
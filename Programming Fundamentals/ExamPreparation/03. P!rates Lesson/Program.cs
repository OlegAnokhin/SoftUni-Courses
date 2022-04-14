using System;
using System.Collections.Generic;

namespace _03._PIrates_Lesson
{
    class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstCommand = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();
            while (firstCommand != "Sail")
            {
                string[] commandArgs = firstCommand.Split("||");

                string cityName = commandArgs[0];
                int population = int.Parse(commandArgs[1]);
                int gold = int.Parse(commandArgs[2]);

                if (cities.ContainsKey(cityName))
                {
                    cities[cityName].Population += population;
                    cities[cityName].Gold += gold;
                }
                else
                {
                    City newCity = new City(cityName, population, gold);
                    cities.Add(cityName, newCity);
                }
                firstCommand = Console.ReadLine();
            }
            string secondCommand = Console.ReadLine();
            while (secondCommand != "End")
            {
                string[] secondCommandArgs = secondCommand.Split("=>");
                string commandType = secondCommandArgs[0];

                if (commandType == "Plunder")
                {
                    string townToPlunder = secondCommandArgs[1];
                    int populationToRemove = int.Parse(secondCommandArgs[2]);
                    int goldToSteal = int.Parse(secondCommandArgs[3]);

                    cities[townToPlunder].Population -= populationToRemove;
                    cities[townToPlunder].Gold -= goldToSteal;

                    Console.WriteLine($"{townToPlunder} plundered! {goldToSteal} gold stolen, {populationToRemove} citizens killed.");

                    if (cities[townToPlunder].Population <=0 || cities[townToPlunder].Gold <= 0)
                    {
                        Console.WriteLine($"{townToPlunder} has been wiped off the map!");
                        cities.Remove(townToPlunder);
                    }
                }
                else if (commandType == "Prosper")
                {
                    string townToPrasper = secondCommandArgs[1];
                    int goldToAdd = int.Parse(secondCommandArgs[2]);
                    if (goldToAdd < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        secondCommand = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cities[townToPrasper].Gold += goldToAdd;
                        Console.WriteLine($"{goldToAdd} gold added to the city treasury. {townToPrasper} now has {cities[townToPrasper].Gold} gold.");
                    }
                }
                    secondCommand = Console.ReadLine();
            }
            if (cities.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    City currentCity = city.Value;
                    Console.WriteLine($"{currentCity.Name} -> Population: {currentCity.Population} citizens, Gold: {currentCity.Gold} kg");
                }
            }
        }
    }
}

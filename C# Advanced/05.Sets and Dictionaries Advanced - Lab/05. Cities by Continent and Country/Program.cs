using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            int citiesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < citiesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];
                AddCity(cities, continent, country, city);
            }
            PrintCitiesByContinent(cities);
        }

        static void PrintCitiesByContinent(Dictionary<string, 
            Dictionary<string, List<string>>> cities)
        {
            foreach (var (continentName, countries) in cities)
            {
                Console.WriteLine(continentName + ":");
                foreach (var (countryName, citiesInCountry) in countries)
                {
                    Console.Write("  " + countryName + " -> ");
                    Console.WriteLine(string.Join(", ", citiesInCountry));
                }

            }
        }

        static void AddCity(Dictionary<string, Dictionary<string, List<string>>> cities, 
            string continent, string country, string city)
        {
            if (!cities.ContainsKey(continent))
            {
                cities.Add(continent, new Dictionary<string, List<string>>());
            }
            Dictionary<string, List<string>> counties = cities[continent];
            if (!counties.ContainsKey(country))
            {
                counties.Add(country, new List<string>());
            }
            counties[country].Add(city);
        }
    }
}

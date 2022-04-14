using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> plantRarity = new Dictionary<string, int>();
            Dictionary<string, List<double>> plantRatings = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] plant = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plant[0];
                int currrarity = int.Parse(plant[1]);
                plantRarity[plantName] = currrarity;
            }
            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                string data = cmdArgs[1];

                string[] cmdData = data
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plantName = cmdData[0];

                if (cmdType == "Rate")
                {
                    double rating = double.Parse(cmdData[1]);
                    if (!plantRarity.ContainsKey(plantName))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    if (!plantRatings.ContainsKey(plantName))
                    {
                        plantRatings[plantName] = new List<double>();
                    }
                    plantRatings[plantName].Add(rating);
                }
                else if (cmdType == "Update")
                {
                    int newRarity = int.Parse(cmdData[1]);
                    if (plantRarity.ContainsKey(plantName))
                    {
                        plantRarity[plantName] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdType == "Reset")
                {
                    if (!plantRarity.ContainsKey(plantName))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    if (plantRatings.ContainsKey(plantName))
                    {
                        plantRatings[plantName].Clear();
                    }
                }
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (KeyValuePair<string, int> kvp in plantRarity)
            {
                string plantName = kvp.Key;
                int rarity = kvp.Value;
                double avgRating = 0;

                if (plantRatings.ContainsKey(plantName) && plantRatings[plantName].Any())
                {
                    avgRating = plantRatings[plantName].Average();
                }
                Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {avgRating:f2}");
            }
        }
    }
}

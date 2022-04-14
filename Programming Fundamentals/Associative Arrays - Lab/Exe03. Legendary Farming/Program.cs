using System;
using System.Linq;
using System.Collections.Generic;

namespace Exe03._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "motes", 0},
                { "fragments", 0 }
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();

            string itemObtained = string.Empty;

            while (String.IsNullOrEmpty(itemObtained))
            {
                string materialsLine = Console.ReadLine().ToLower();
                string[] materialArr = materialsLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                ProcesedInputLine(keyMaterials, junk, materialArr, ref itemObtained);
            }
            PrintOutput(keyMaterials, junk, itemObtained);
        }
        static void ProcesedInputLine(Dictionary<string, int> keyMaterials
            , Dictionary<string, int> junk
            , string[] materialArr, ref string itemObtained)
        {
            const int minCraftMaterialQty = 250;
            Dictionary<string, string> craftingTable = new Dictionary<string, string>()
            {
                { "shards",  "Shadowmourne"},
                { "fragments", "Valanyr" },
                { "motes", "Dragonwrath" }
            };

            for (int i = 0; i < materialArr.Length; i += 2)
            {
                int currMaterialQty = int.Parse(materialArr[i]);
                string currMaterial = materialArr[i + 1];

                if (keyMaterials.ContainsKey(currMaterial))
                {
                    keyMaterials[currMaterial] += currMaterialQty;

                    if (keyMaterials[currMaterial] >= minCraftMaterialQty)
                    {
                        itemObtained = craftingTable[currMaterial];
                        keyMaterials[currMaterial] -= minCraftMaterialQty;

                        break;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(currMaterial))
                    {
                        junk[currMaterial] = 0;
                    }
                    junk[currMaterial] += currMaterialQty;
                }
            }

        }

        static void PrintOutput(Dictionary<string, int> keyMaterialLeft
            , Dictionary<string, int> junk
            , string itemObtained)
        {
            Console.WriteLine($"{itemObtained} obtained!");
            foreach (var kvp in keyMaterialLeft)
            {
                string keyMaterial = kvp.Key;
                int qtyLeft = kvp.Value;
                Console.WriteLine($"{keyMaterial}: {qtyLeft}");
            }
            foreach (var kvp in junk)
            {
                string junkMaterial = kvp.Key;
                int junkqty = kvp.Value;
                Console.WriteLine($"{junkMaterial}: {junkqty}");
            }
        }

    }
}

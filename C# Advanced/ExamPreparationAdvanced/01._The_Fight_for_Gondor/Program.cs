using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._The_Fight_for_Gondor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfVawes = int.Parse(Console.ReadLine());
            Stack<int> plates = new Stack<int>(Console.ReadLine()
                 .Split().Select(int.Parse).Reverse());
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= numberOfVawes; i++)
            {
                var currentWave = Console.ReadLine().Split().Select(int.Parse);
                foreach (var orc in currentWave)
                {
                    orcs.Push(orc);
                }
                if (i % 3 == 0)
                {
                    int plate = int.Parse(Console.ReadLine());
                    var platesList = plates.ToList();
                    platesList.Add(plate);
                    platesList.Reverse();
                    plates = new Stack<int>(platesList);
                }
                while (plates.Count > 0 && orcs.Count > 0)
                {
                    int currentPlate = plates.Pop();
                    int currentOrc = orcs.Pop();
                    if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;
                        plates.Push(currentPlate);
                    }
                    else if (currentPlate < currentOrc)
                    {
                        currentOrc -= currentPlate;
                        orcs.Push(currentOrc);
                    }
                }
                if (plates.Count <= 0)
                {
                    break;
                }
            }
            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}

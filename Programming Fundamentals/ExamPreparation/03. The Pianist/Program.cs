using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> collection = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|")
                    .ToArray();
                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                if (!collection.ContainsKey(piece))
                {
                    collection[piece] = new List<string>() { "", "" };
                }
                collection[piece][0] = composer;
                collection[piece][1] = key;
            }
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split("|")
                    .ToArray();
                string cmdType = cmdArgs[0];
                if (cmdType == "Add")
                {
                    string piece = cmdArgs[1];
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];
                    if (collection.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                        continue;
                    }
                    collection[piece] = new List<string>() { "", "" };
                    collection[piece][0] = composer;
                    collection[piece][1] = key;
                    Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                }
                else if (cmdType == "Remove")
                {
                    string piece = cmdArgs[1];
                    if (collection.ContainsKey(piece))
                    {
                        collection.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (cmdType == "ChangeKey")
                {
                    string piece = cmdArgs[1];
                    string newKey = cmdArgs[2];
                    if (collection.ContainsKey(piece))
                    {
                        collection[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }
            foreach (var kvp in collection)
            {
                string currpiece = kvp.Key;
                string composer = kvp.Value[0];
                string key = kvp.Value[1];

                Console.WriteLine($"{currpiece} -> Composer: {composer}, Key: {key}");

            }
        }
    }
}

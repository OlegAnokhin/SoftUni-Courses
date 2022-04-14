using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExamSolution03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> Like =
                new Dictionary<string, List<string>>();

            int unlikeCount = 0;
            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] cmdInfo = cmd
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdInfo[0];

                if (cmdType == "Like")
                {
                    string name = cmdInfo[1];
                    string food = cmdInfo[2];
                    if (!Like.ContainsKey(name))
                    {
                        Like[name] = new List<string>();
                    }
                    if (Like[name].Contains(food))
                    {
                        continue;
                    }
                    Like[name].Add(food);
                }
                else if (cmdType == "Dislike")
                {
                    string name = cmdInfo[1];
                    string food = cmdInfo[2];

                    if (!Like.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is not at the party.");
                        continue;
                    }
                    else if (Like[name].Contains(food))
                    {
                        Like[name].Remove(food);
                        unlikeCount++;
                        Console.WriteLine($"{name} doesn't like the {food}.");
                    }
                    else if (!Like[name].Contains(food))
                    {
                        Console.WriteLine($"{name} doesn't have the {food} in his/her collection.");
                    }
                }
            }
                    List<string> likeList = new List<string>();

            foreach (var key in Like.Keys)
            {
                foreach (var values in Like[key])
                {
                    likeList.Add(values);

                }
                    Console.WriteLine($"{key}: {string.Join(", ", likeList)}");
                likeList.Clear();
            }
            Console.WriteLine($"Unliked meals: {unlikeCount}");
        }
    }
}

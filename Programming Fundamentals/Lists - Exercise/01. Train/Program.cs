using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberPassenger = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command;
            int peopleCount = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArg[0];

                if (cmdType == "Add")
                {
                    int apendNumber = int.Parse(cmdArg[1]);
                    numberPassenger.Add(apendNumber);
                }
                if (cmdArg.Length == 1)
                {
                    peopleCount = int.Parse(cmdArg[0]);
                    for (int i = 0; i < numberPassenger.Count; i++)
                    {
                        if (numberPassenger[i] + peopleCount <= capacity)
                        {
                            numberPassenger[i] += peopleCount;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ", numberPassenger));
        }
    }
}
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace P08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArgs[0];

                if (cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    Merge(words, startIndex, endIndex);
                }
                else if (cmdType == "divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partitionsCount = int.Parse(cmdArgs[2]);

                    Divide(words, index, partitionsCount);
                }
            }

            Console.WriteLine(String.Join(" ", words));
        }

        static void Merge(List<string> words, int startIndex, int endIndex)
        {
            if (!IsIndexValid(words, startIndex))
            {
                startIndex = 0;
            }

            if (!IsIndexValid(words, endIndex))
            {
                endIndex = words.Count - 1;
            }

            StringBuilder merged = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                merged.Append(words[startIndex]);
                words.RemoveAt(startIndex);
            }
            words.Insert(startIndex, merged.ToString());
        }

        static void Divide(List<string> words, int elementIndex, int partitionsCount)
        {
            string word = words[elementIndex];

            if (partitionsCount > word.Length)
            {
                return;
            }

            int partitionsLength = word.Length / partitionsCount;
            int paritionsReminder = word.Length % partitionsCount;
            int lastPartitionLength = partitionsLength + paritionsReminder;

            List<string> paritions = new List<string>();
            for (int iter = 0; iter < partitionsCount; iter++)
            {
                char[] currentPartition;

                if (iter == partitionsCount - 1)
                {
                    currentPartition = word
                        .Skip(iter * partitionsLength)
                        .Take(lastPartitionLength)
                        .ToArray();
                }
                else
                {
                    currentPartition = word
                        .Skip(iter * partitionsLength)
                        .Take(partitionsLength)
                        .ToArray();
                }

                paritions.Add(new string(currentPartition));
            }

            words.RemoveAt(elementIndex);
            words.InsertRange(elementIndex, paritions);
        }

        static bool IsIndexValid(List<string> words, int index)
        {
            return index >= 0 && index < words.Count;
        }
    }
}
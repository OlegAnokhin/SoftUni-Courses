using System;
using System.Linq;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            string input = Console.ReadLine();
            //            string command = Console.ReadLine();

            //            while (command != "Travel")
            //            {
            //                string[] commandArgs = command.Split(":");
            //                string commandType = commandArgs[0];

            //                if (commandType == "Add Stop")
            //                {
            //                    int index = int.Parse(commandArgs[1]);
            //                    string addedStop = commandArgs[2];
            //                    if (index >= 0 && index <= input.Length)
            //                    {
            //                        input = input.Insert(index, addedStop);
            //                    }
            //                        Console.WriteLine(input);
            //                }
            //                else if (commandType == "Remove Stop")
            //                {
            //                    int startIndex = int.Parse(commandArgs[1]);
            //                    int endIndex = int.Parse(commandArgs[2]);
            //                    int wordLength = endIndex - startIndex;
            //                    if (startIndex >= 0 && startIndex <= input.Length && endIndex < input.Length)
            //                    {
            //                        input = input.Remove(startIndex, wordLength + 1);
            //                    }
            //                        Console.WriteLine(input);
            //                }
            //                else if (commandType == "Switch")
            //                {
            //                    string oldString = commandArgs[1];
            //                    string newString = commandArgs[2];
            //                    input = input.Replace(oldString, newString);
            //                    Console.WriteLine(input);
            //                }
            //                command = Console.ReadLine();
            //            }
            //            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
            //        }
            //    }
            //}

            string stopsStr = Console.ReadLine();
            string cmdInfo;
            while ((cmdInfo = Console.ReadLine()) != "Travel")
            {
                string[] cmdArg = cmdInfo
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArg[0];
                if (cmdType == "Add Stop")
                {
                    int insertIndex = int.Parse(cmdArg[1]);
                    string insertStr = cmdArg[2];
                    stopsStr = InsertStringIndex(stopsStr, insertIndex, insertStr);
                    Console.WriteLine(stopsStr);
                }
                else if (cmdType == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int endIndex = int.Parse(cmdArg[2]);
                    stopsStr = RemoveStringInRange(stopsStr, startIndex, endIndex);
                    Console.WriteLine(stopsStr);
                }
                else if (cmdType == "Switch")
                {
                    string oldString = cmdArg[1];
                    string newString = cmdArg[2];
                    stopsStr = ReplaceAllOccurance(stopsStr, oldString, newString);
                    Console.WriteLine(stopsStr);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stopsStr}");
        }
    
         static string InsertStringIndex(string originalStr, int insertIndex, string insertStr)
        {
            if (!IsIndexValid(originalStr, insertIndex))
            {
                return originalStr;
            }
            string modifiedStr = originalStr.Insert(insertIndex, insertStr);
            return modifiedStr;
        }
        static string RemoveStringInRange(string originalStr, int startIndex, int endIndex)
        {
            {
                if (!IsIndexValid(originalStr,startIndex))
                {
                    return originalStr;
                }
                if (!IsIndexValid(originalStr, endIndex))
                {
                    return originalStr;
                }
                string modifiedString = originalStr.Remove(startIndex, endIndex - startIndex + 1);
                return modifiedString;
            }
        }
        static string ReplaceAllOccurance(string originalStr, string oldString, string newString)
        {
            string modifieldString = originalStr.Replace(oldString, newString);
            return modifieldString;
        }
        static bool IsIndexValid(string str, int index)
        {
            return index >= 0 && index < str.Length;
        }

    }
}
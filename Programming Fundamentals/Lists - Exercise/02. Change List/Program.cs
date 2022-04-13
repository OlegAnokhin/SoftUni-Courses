using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArg[0];

                if (cmdType == "Delete")
                {
                    int deleteNumber = int.Parse(cmdArg[1]);
                    //numbers.Remove(deleteNumber);
                    //if (numbers.Contains(deleteNumber))
                    //{
                    //    numbers.Remove(deleteNumber);
                    //}

                     numbers.RemoveAll(x => x == deleteNumber);

                }

                else if (cmdType == "Insert")
                {
                    int insertNumber = int.Parse(cmdArg[1]);
                    int index = int.Parse(cmdArg[2]);

                    numbers.Insert(index, insertNumber);
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}

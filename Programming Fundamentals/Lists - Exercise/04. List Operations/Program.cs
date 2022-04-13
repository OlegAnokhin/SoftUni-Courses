using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
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
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArg[0];

                if (cmdType == "Add")
                {
                    int apendNumber = int.Parse(cmdArg[1]);
                    numbers.Add(apendNumber);
                }
                else if (cmdType == "Insert")
                {
                    int insertNumber = int.Parse(cmdArg[1]);
                    int index = int.Parse(cmdArg[2]);

                    if (!IsIndexValid(numbers, index))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, insertNumber);
                }
                else if (cmdType == "Remove")
                {
                    int removeIndex = int.Parse(cmdArg[1]);

                    if (!IsIndexValid(numbers, removeIndex))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(removeIndex);
                }
                else if(cmdType == "Shift")
                {
                    string direction = cmdArg[1];
                    int count = int.Parse(cmdArg[2]);

                    if (direction == "left")
                    {
                        ShiftLeft(numbers, count);
                    }
                    else if (direction == "right")
                    {
                        ShifRight(numbers, count);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }

        static bool IsIndexValid(List<int> number, int index)
        {
            return index >= 0 && index < number.Count;
        }


        static void ShiftLeft(List<int> numbers, int count)
        {
            int realPerformedCount = count % numbers.Count;
            for (int cnt = 1; cnt <= realPerformedCount; cnt++)
            {
                int firstElement = numbers.First();
                numbers.Remove(firstElement);
                numbers.Add(firstElement);
            }
        }

        static void ShifRight(List<int> numbers, int count)
        {
            int realPerformedCound = count % numbers.Count;
            for (int cnt = 1; cnt <= realPerformedCound; cnt++)
            {
                int lastElement = numbers.Last();
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastElement);
            }
        }
    }
}

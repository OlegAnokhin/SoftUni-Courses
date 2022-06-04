using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] addFilters = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string addRemove = addFilters[0];
                string condition = addFilters[1];
                string arg = addFilters[2];

                if (addRemove.StartsWith("Add"))
                {
                    Predicate<string> currPredicat = GetPredicate(condition, arg);
                    filters.Add(arg, currPredicat);
                }
                else if (addRemove.StartsWith("Remove"))
                {
                    Predicate<string> currPredicat = GetPredicate(condition, arg);
                    filters.Remove(arg);
                }
            }

               foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }
                Console.WriteLine(string.Join(" ", people));
        }

        public static Predicate<string> GetPredicate(string command, string arg)
        {
            Predicate<string> predicate = null;
            if (command == "Starts with")
            {
                predicate = name => name.StartsWith(arg);
            }
            else if (command == "Ends with")
            {
                predicate = name => name.EndsWith(arg);
            }
            else if (command == "Length")
            {
                predicate = name => name.Length == int.Parse(arg);
            }
            else if (command == "Contains")
            {
                predicate = name => name.Contains(arg);
            }
            else
            {
                Console.WriteLine("Invalid command type: " + command);
            }
            return predicate;
        }
    }
}
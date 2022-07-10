namespace _04.BorderControl
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using _05.BirthdayCelebrations.Models;
    using _05.BirthdayCelebrations.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> identifiers = new List<IBirthable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                if (model == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];
                    identifiers.Add(new Citizen(name, age, id, birthdate));
                }
                else if (model == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];
                    identifiers.Add(new Pet(name, birthdate));
                }
            }
            int year = int.Parse(Console.ReadLine());
            identifiers.Where(y => y.Birthdate.Year == year)
                .Select(y => y.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));
        }
    }
}
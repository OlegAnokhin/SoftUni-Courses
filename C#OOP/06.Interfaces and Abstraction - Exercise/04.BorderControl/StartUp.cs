using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiers = new List<IIdentifiable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    identifiers.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = input[0];
                    string id = input[1];
                    identifiers.Add(new Robot(model, id));
                }
            }
            var fakeNum = Console.ReadLine();
            identifiers.Where(i => i.Id.EndsWith(fakeNum))
                .Select(i => i.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

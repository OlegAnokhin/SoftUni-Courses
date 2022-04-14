using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Order_by_Age
{
    public class People
    {
        public People(string nameOfPerson, string idOfPerson, int ageOfPerson)
        {
            NameOfPerson = nameOfPerson;
            IDOfPerson = idOfPerson;
            AgeOfPerson = ageOfPerson;
        }
        public string NameOfPerson { get; set; }
        public string IDOfPerson { get; set; }
        public int AgeOfPerson { get; set; }

        public override string ToString()
        {
            return $"{this.NameOfPerson} with ID: {this.IDOfPerson} is {this.AgeOfPerson} years old.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> list = new List<People>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] order = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string currName = order[0];
                string currId = order[1];
                int age = int.Parse(order[2]);

                People people = new People(currName, currId, age);
                People sameIdPerson = list.FirstOrDefault(t => t.IDOfPerson == currId);

                if (sameIdPerson == null)
                {
                list.Add(people);
                }
                else
                {
                    sameIdPerson.NameOfPerson = currName;
                    sameIdPerson.IDOfPerson = currId;
                    sameIdPerson.AgeOfPerson = age;
                }

                input = Console.ReadLine();
            }

            List<People> orderedList = list.OrderBy(a => a.AgeOfPerson).ToList();

            foreach (People people in orderedList)
            {
                Console.WriteLine(people);
            }
        }
    }
}

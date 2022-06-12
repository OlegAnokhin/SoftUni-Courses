using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        public Clinic(int capacity)
        {
            this.pets = new List<Pet>();
            this.Capacity = capacity;
        }
        public int Capacity { get; set; }
        public int Count => pets.Count;

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name);
            return pets.Remove(pet);
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return pet;
        }
        public Pet GetOldestPet()
        {
            Pet pet = pets.OrderByDescending(x => x.Age).FirstOrDefault();
            return pet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

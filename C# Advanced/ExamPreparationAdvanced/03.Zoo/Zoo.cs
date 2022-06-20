using System.Linq;
using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals;
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Animals = new List<Animal>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (Animals.Count + 1 > this.Capacity)
            {
                return "The zoo is full.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int count = this.Animals.RemoveAll(a => a.Species == species);
            return count;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> matchAnimals = this.Animals.Where(d => d.Diet == diet).ToList();
            return matchAnimals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var animalByWeight = this.Animals.First(w => w.Weight == weight);
            return animalByWeight;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> matchAnimals = this.Animals
                .Where(l => l.Length >= minimumLength && l.Length <= maximumLength)
                .ToList();
            int count = matchAnimals.Count();
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
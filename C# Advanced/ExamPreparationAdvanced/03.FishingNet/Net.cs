using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.Fish = new List<Fish>();
        }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Fish.Count;
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) ||
                fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Fish.Count + 1 > this.Capacity)
            {
                return "Fishing net is full.";
            }
            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(f => f.Weight == weight);
            if (fish != null)
            {
                return this.Fish.Remove(fish);
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            var fish = this.Fish.FirstOrDefault(f => f.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            var biggestFish = this.Fish.Max(l => l.Length);
            var fish = this.Fish.FirstOrDefault(x => x.Length == biggestFish);
            return fish;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");
            foreach (Fish fish in this.Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

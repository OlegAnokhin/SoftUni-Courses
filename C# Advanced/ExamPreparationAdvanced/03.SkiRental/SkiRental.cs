using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental()
        {
            this.data = new List<Ski>();
        }
        public SkiRental(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = data.FirstOrDefault(m => m.Manufacturer == manufacturer 
            && m.Model == model);
            if (skiToRemove == null)
            {
                return false;
            }
            return data.Remove(skiToRemove);
        }
        public Ski GetNewestSki()
        {
            var newestSki = this.data.Max(l => l.Year);
            var newest = this.data.FirstOrDefault(x => x.Year == newestSki);
            if (newest == null)
            {
                return null;
            }
            return newest;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
            if (ski == null)
            {
                return null;
            }
            return ski;
        }
        public int Count => this.data.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine($"{ski}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
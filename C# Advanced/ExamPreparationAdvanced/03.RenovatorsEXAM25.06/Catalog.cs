using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            this.renovators = new List<Renovator>();
        }
        public int Count => this.renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)
                || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (renovators.Count + 1 > this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate >= 350)
            {
                return "Invalid renovator's rate.";
            }
            this.renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            var currRenovator = this.renovators.FirstOrDefault(f => f.Name == name);
            if (name != null)
            {
                return this.renovators.Remove(currRenovator);
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = this.renovators.RemoveAll(r => r.Type == type);
            if (count > 0)
            {
                return count;
            }
            return 0;
        }
        public Renovator HireRenovator(string name)
        {
            Renovator currRenovator = this.renovators.FirstOrDefault(r =>r.Name == name);
            if (currRenovator == null)
            {
                return null;
            }
            else
            {
                currRenovator.Hired = true;
                return currRenovator;
            }
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> MatchRenovators = this.renovators.Where(d => d.Days >= days).ToList();
            return MatchRenovators;
        }
        public string Report()
        {
            var renovatorsAvailable = this.renovators.Where(r => r.Hired == false);
            return $"Renovators available for Project  {this.Project}:" + Environment.NewLine +
                   string.Join(Environment.NewLine, renovatorsAvailable);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }
        public int Count => this.Drones.Count(d => d.Available == true);

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (this.Drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }
            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            int count = this.Drones.RemoveAll(dr => dr.Name == name);
            return count > 0;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = this.Drones.RemoveAll(dr => dr.Brand == brand);
            return count;
        }
        public Drone FlyDrone(string name)
        {
            Drone d = this.Drones.FirstOrDefault(d => d.Name == name);
            if (d == null)
            {
                return null;
            }
            else
            {
                d.Available = false;
                return d;
            }
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> MatchDrones = this.Drones.Where(d => d.Range >= range).ToList();
            foreach (var drone in MatchDrones)
            {
                drone.Available = false;
            }
                return MatchDrones;
        }
        public string Report()
        {
            var dronesAvailable = this.Drones.Where(dr => dr.Available == true);
            return $"Drones available at {this.Name}:" + Environment.NewLine +
                   string.Join(Environment.NewLine, dronesAvailable);
        }
    }
}

using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            equipment = new HashSet<IEquipment>();
            athletes = new HashSet<IAthlete>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                this.capacity = value;
            }
        }
        public double EquipmentWeight => equipment.Sum(eq => eq.Weight);
        public ICollection<IEquipment> Equipment => equipment;
        public ICollection<IAthlete> Athletes => athletes;
        public virtual void AddAthlete(IAthlete athlete)
        {
            Athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            if (!Athletes.Remove(athlete))
            {
                return false;
            }
            Athletes.Remove(athlete);
            return true;
        }
        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }
        public void Exercise()
        {
            if (athletes.Any())
            {
                foreach (var athlete in athletes)
                {
                    athlete.Exercise();
                }
            }
        }
        public string GymInfo()
        {
            var sb = new StringBuilder();
            var athleteExist = Athletes.Count == 0 ? "No athletes" : string.Join(", ", Athletes.Select(fn => fn.FullName));
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.AppendLine($"Athletes: {athleteExist}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");
            return sb.ToString().Trim();
        }
    }
}
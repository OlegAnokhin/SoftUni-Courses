using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => this.Participants.Count();
        public void Add(Car car)
        {
           // if (Race.LicensePlate != car.LicensePlate)

            if (Participants.Count > this.Capacity 
                || car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            Car carToRemove = Participants.FirstOrDefault(m => m.LicensePlate == licensePlate);
            if (carToRemove == null)
            {
                return false;
            }
            return Participants.Remove(carToRemove);
        }
        public Car FindParticipant(string licensePlate)
        {
            foreach (Car car in Participants)
            {
                if (car.LicensePlate == licensePlate)
                {
                    return car;
                }
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            var mostPowerful = this.Participants.Max(l => l.HorsePower);
            var currCar = this.Participants.FirstOrDefault(x => x.HorsePower == mostPowerful);
            if (currCar == null)
            {
                return null;
            }
            return currCar;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}

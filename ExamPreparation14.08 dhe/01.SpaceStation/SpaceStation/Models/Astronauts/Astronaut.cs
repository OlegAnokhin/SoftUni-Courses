using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            bag = new Backpack();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        (ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }
        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }
        public virtual bool CanBreath => Oxygen >= 10.00;
        public IBag Bag => bag;

        public virtual void Breath()
        {
            if (Oxygen - 10 <= 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 10.00;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var bagCondition = Bag.Items.Count == 0 ? "none" : string.Join(", ", bag.Items);
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");
            sb.AppendLine($"Bag items: {bagCondition}");
            return sb.ToString().Trim();
        }
    }
}
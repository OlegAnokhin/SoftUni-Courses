using SpaceStation.Models.Planets.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> planets;
        public Planet(string name)
        {
            this.name = name;
            planets = new List<string>();
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
                        (ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
        public ICollection<string> Items
        {
            get
            {
                return this.planets;
            }
            set
            {
                this.planets = value;
            }
        }
    }
}
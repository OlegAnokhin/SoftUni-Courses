using System;
using System.Text;
using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly ICollection<IDye> dyes;
        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
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
                    throw new ArgumentException
                        (ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }
        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }
        public ICollection<IDye> Dyes => dyes;
        public abstract void Work();
        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }
    }
}
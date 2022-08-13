using System;
using System.Text;
using System.Collections.Generic;
using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;
        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
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
                        (ExceptionMessages.InvalidEggName);
                }
                this.name = value;
            }
        }
        public int EnergyRequired
        {
            get
            {
                return this.energyRequired;
            }
            set
            {
                if (value < 0)
                {
                    EnergyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }
        public void GetColored()
        {
            EnergyRequired -= 10;
            if (EnergyRequired <= 0)
            {
                EnergyRequired = 0;
            }
        }
        public bool IsDone()
        {
            if (EnergyRequired <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
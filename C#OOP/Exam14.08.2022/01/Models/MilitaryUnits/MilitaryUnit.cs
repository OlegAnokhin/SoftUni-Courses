using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;
        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = enduranceLevel;
        }
        public double Cost { get; }
        public int EnduranceLevel
        {
            get
            {
                return this.enduranceLevel;
            }
            set
            {
                this.enduranceLevel = value;
            }
        }
        public void IncreaseEndurance()
        {
            EnduranceLevel += 1;
            if (EnduranceLevel > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException
                    (ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
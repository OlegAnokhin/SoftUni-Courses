using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Text;
using System.Collections.Generic;

namespace Formula1.Models.Pilots
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidPilot, FullName);
                }
                this.fullName = value;
            }
        }
        public bool CanRace
        {
            get 
            { 
                return canRace; 
            }
            set 
            {
                this.canRace = value;
            }
        }
        public IFormulaOneCar Car
        {
            get
            {
                return this.car;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException
                        (ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }
        public int NumberOfWins { get; set; }
        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }
        public void WinRace()
        {
                this.NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
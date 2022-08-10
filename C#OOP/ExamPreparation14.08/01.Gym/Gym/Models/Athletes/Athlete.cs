using Gym.Models.Athletes.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;
        public Athlete(string fullName, string motivation, int stamina, int numberOfMedals)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
            this.NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get 
            { 
                return fullName; 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidAthleteName);
                }
                this.fullName = value;
            }
        }
        public string Motivation
        {
            get
            {
                return motivation;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidAthleteMotivation);
                }
                this.motivation = value;
            }
        }
        public int Stamina
        {
            get
            {
                return stamina;
            }
            set
            {
                this.stamina = value;
            }
        }
        public int NumberOfMedals
        {
            get
            {
                return numberOfMedals;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidAthleteMedals);
                }
            }
        }
        public abstract void Exercise();
    }
}

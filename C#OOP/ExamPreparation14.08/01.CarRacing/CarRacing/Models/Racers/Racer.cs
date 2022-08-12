using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRacerName);
                }
                this.username = value;
            }
        }
        public string RacingBehavior
        {
            get
            {
                return this.racingBehavior;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get
            {
                return this.drivingExperience;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.drivingExperience = value;
            }
        }
        public ICar Car
        {
            get
            {
                return this.car;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRacerCar);
                }
                this.car = value;
            }
        }
        public bool IsAvailable()
        {
            if (Car.FuelAvailable >= car.FuelConsumptionPerRace)
            {
                return true;
            }
            return false;
        }
        public virtual void Race()
        {
            Car.Drive();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {car.Make} {car.Model} ({car.VIN})");
            return sb.ToString().TrimEnd();
        }
    }
}
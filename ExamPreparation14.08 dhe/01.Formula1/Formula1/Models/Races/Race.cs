﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Text;
using System.Collections.Generic;

namespace Formula1.Models.Races
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private ICollection<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get
            {
                return this.raceName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRaceName, RaceName);
                }
                this.raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidLapNumbers, NumberOfLaps.ToString());
                }
                this.numberOfLaps = value;
            }
        }
        public bool TookPlace
        {
            get
            {
                return this.tookPlace;
            }
            set
            {
                this.tookPlace = value;
            }
        }
        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }
        public string RaceInfo()
        {
            var sb = new StringBuilder();
            var TookPlace = this.TookPlace == true ? "Yes" : "No";

            sb.AppendLine($"The {this.RaceName} race has:")
                .AppendLine($"Participants: {this.Pilots.Count}")
                .AppendLine($"Number of laps: {this.NumberOfLaps}")
                .AppendLine($"Took place: {TookPlace}");
            return sb.ToString().TrimEnd();
        }
    }
}
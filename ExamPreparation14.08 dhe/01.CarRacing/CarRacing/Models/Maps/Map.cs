using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.
                    OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerTwo.IsAvailable() && !racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.
                    OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.
                    RaceCannotBeCompleted);
            }
            var RBMforRacerOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var RBMforRacerTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var chanceOfWinningforRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * RBMforRacerOne;
            var chanceOfWinningforRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * RBMforRacerTwo;
            racerOne.Race();
            racerTwo.Race();
            if (chanceOfWinningforRacerOne > chanceOfWinningforRacerTwo)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}

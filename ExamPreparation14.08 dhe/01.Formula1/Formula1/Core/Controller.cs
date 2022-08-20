using Formula1.Core.Contracts;
using Formula1.Models.Cars;
using Formula1.Models.Contracts;
using Formula1.Models.Pilots;
using Formula1.Models.Races;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly FormulaOneCarRepository formulaCarRep;
        private readonly PilotRepository pilotRep;
        private readonly RaceRepository raceRep;
        public Controller()
        {
            this.formulaCarRep = new FormulaOneCarRepository();
            this.pilotRep = new PilotRepository();
            this.raceRep = new RaceRepository();
        }
        public string CreatePilot(string fullName)
        {
            if (pilotRep.FindByName(fullName) != null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            Pilot pilot = new Pilot(fullName);
            pilotRep.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar formulaOneCar;
            if (type == "Ferrari")
            {
                formulaOneCar = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                formulaOneCar = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if (formulaCarRep.FindByName(model) != null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            formulaCarRep.Add(formulaOneCar);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRep.FindByName(raceName) != null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            Race raceToAdd = new Race(raceName, numberOfLaps);
            raceRep.Add(raceToAdd);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRep.FindByName(pilotName);
            IFormulaOneCar car = formulaCarRep.FindByName(carModel);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else if (car == null)
            {
                throw new NullReferenceException
                    (String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            formulaCarRep.Remove(car);
            return String.Format(OutputMessages
                .SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }
        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRep.FindByName(raceName);
            IPilot pilot = pilotRep.FindByName(pilotFullName);
            if (race == null)
            {
                throw new NullReferenceException
                    (String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilot == null || pilot.CanRace == false || 
                race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.Pilots.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            IRace race = raceRep.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException
                    (String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            race.TookPlace = true;
            List<IPilot> ordered = race.Pilots
                .OrderByDescending(r => r.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3).ToList();
            IPilot first = ordered[0];
            IPilot second = ordered[1];
            IPilot third = ordered[2];
            first.WinRace();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, first.FullName, race.RaceName));
            sb.AppendLine(String.Format(OutputMessages.PilotSecondPlace, second.FullName, race.RaceName));
            sb.AppendLine(String.Format(OutputMessages.PilotThirdPlace, third.FullName, race.RaceName));
            return sb.ToString().TrimEnd();
        }
        public string PilotReport()
        {
            var orderedPilots = pilotRep.Models.OrderByDescending(p => p.NumberOfWins);
            var sb = new StringBuilder();
            foreach (var pilot in orderedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string RaceReport()
        {
            List<IRace> finishedRaces = raceRep.Models
                .Where(r => r.TookPlace == true).ToList();
            var sb = new StringBuilder();
            foreach (var race in finishedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
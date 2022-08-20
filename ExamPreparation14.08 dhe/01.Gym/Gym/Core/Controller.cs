using Gym.Core.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using Gym.Repositories;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Gyms;
using Gym.Utilities.Messages;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Equipment;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment currEquipment;
            if (equipmentType == nameof(BoxingGloves))
            {
                currEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                currEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidEquipmentType);
            }
            equipment.Add(currEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currEquipment = equipment.Models
                .FirstOrDefault(eq => eq.GetType().Name == equipmentType);
            var currGym = gyms.FirstOrDefault(gn => gn.Name == gymName);
            if (currEquipment == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            if (currGym == null)
            {
                return string.Empty;
            }
            currGym.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete currAthlete;
            if (athleteType == nameof(Boxer))
            {
                currAthlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                currAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAthleteType);
            }
            var currGym = gyms.FirstOrDefault(g => g.Name == gymName);
            var gymType = currGym.GetType().Name;
            if (athleteType == nameof(Boxer) && gymType != nameof(BoxingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }
            if (athleteType == nameof(Weightlifter) && gymType != nameof(WeightliftingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }
            currGym.AddAthlete(currAthlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }
        public string TrainAthletes(string gymName)
        {
            var currGym = gyms.FirstOrDefault(g => g.Name == gymName);
            currGym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, currGym.Athletes.Count());
        }
        public string EquipmentWeight(string gymName)
        {
            var currGym = gyms.FirstOrDefault(g => g.Name == gymName);
            var currEquipmentWeigth = currGym.EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, currEquipmentWeigth);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
using System;
using System.Text;
using System.Collections.Generic;
using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int weightliftingGymCapacity = 20;
        public WeightliftingGym(string name) 
            : base(name, weightliftingGymCapacity)
        {
        }
        public override void AddAthlete(IAthlete athlete)
        {
            if (Capacity <= Athletes.Count)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NotEnoughSize);
            }
            base.AddAthlete(athlete);
        }

    }
}

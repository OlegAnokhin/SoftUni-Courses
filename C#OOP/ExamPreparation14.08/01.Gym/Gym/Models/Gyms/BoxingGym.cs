using System;
using System.Text;
using System.Collections.Generic;
using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int boxinGymCapacity = 15;
        public BoxingGym(string name) 
            : base(name, boxinGymCapacity)
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
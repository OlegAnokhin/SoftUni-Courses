using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int defaultStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, defaultStamina, numberOfMedals)
        {
        }
        public override void Exercise()
        {
            if (Stamina + 15 > 100)
            {
                Stamina = 100;
                throw new ArgumentException
                    (ExceptionMessages.InvalidStamina);
            }
            Stamina += 15;
        }
    }
}
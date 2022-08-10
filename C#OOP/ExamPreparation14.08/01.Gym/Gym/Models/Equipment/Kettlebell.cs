using System;
using System.Text;
using System.Collections.Generic;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double kettlebellWeights = 10000.00;
        private const decimal kettlebellPrice = 80;
        public Kettlebell()
            : base(kettlebellWeights, kettlebellPrice)
        {
        }
    }
}
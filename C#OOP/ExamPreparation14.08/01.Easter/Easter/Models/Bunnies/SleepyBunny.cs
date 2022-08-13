using System;
using System.Text;
using System.Collections.Generic;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int defEnergy = 50;
        public SleepyBunny(string name) 
            : base(name, defEnergy)
        {
        }
        public override void Work()
        {
            Energy -= 15;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
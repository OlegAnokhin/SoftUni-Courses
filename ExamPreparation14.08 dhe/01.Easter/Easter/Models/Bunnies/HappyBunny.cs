using System;
using System.Text;
using System.Collections.Generic;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int defEnergy = 100;
        public HappyBunny(string name) 
            : base(name, defEnergy)
        {
        }

        public override void Work()
        {
            Energy -= 10;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
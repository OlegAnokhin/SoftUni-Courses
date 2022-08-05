using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int FreshWaterFishInitalSize = 3;
        private const int FreshWaterFishIncrSize = 3;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = FreshWaterFishInitalSize;
        }
        public override void Eat()
        {
            this.Size += FreshWaterFishInitalSize;
        }
    }
}

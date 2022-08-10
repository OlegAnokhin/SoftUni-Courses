using System;
using System.Text;
using System.Collections.Generic;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double boxingGlWeights = 227.00;
        private const decimal boxingGlPrice = 120;
        public BoxingGloves() 
            : base(boxingGlWeights, boxingGlPrice)
        {
        }
    }
}

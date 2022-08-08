using System;
using System.Text;
using System.Collections.Generic;

namespace Formula1.Models.Cars
{
    public class Williams : FormulaOneCar
    {
        public Williams(string model, int horsepower, double engineDisplacement) 
            : base(model, horsepower, engineDisplacement)
        {
        }
    }
}
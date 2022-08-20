using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Text;
using System.Collections.Generic;

namespace Formula1.Models.Cars
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;
        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidF1CarModel, Model);
                }
                this.model = value;
            }
        }
        public int Horsepower
        {
            get
            {
                return this.horsepower;
            }
            set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidF1HorsePower, Horsepower.ToString());
                }
                this.horsepower = value;
            }
        }
        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;
            }
            set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidF1EngineDisplacement, EngineDisplacement.ToString());
                }
                this.engineDisplacement = value;
            }
        }
        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
    }
}
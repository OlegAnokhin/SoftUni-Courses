using System;
using System.Text;
using System.Collections.Generic;

namespace _07.RawData
{
    public class Car
    {
        private Tire[] tires;
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires
        {
            get => tires;
            set
            {
                if (value.Length == 4)
                {
                    tires = value;
                }
            }
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
    }
}

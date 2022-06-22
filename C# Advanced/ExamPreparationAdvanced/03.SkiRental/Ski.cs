using System;
using System.Text;
using System.Collections.Generic;

namespace SkiRental
{
    public class Ski
    {
        public Ski(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            return $"{this.Manufacturer} - {this.Model} - {this.Year}";
        }
    }
}
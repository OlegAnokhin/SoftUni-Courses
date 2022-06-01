using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public void Drive (double distance)
        {
            double consumpion = distance * this.fuelConsumption;
            if (consumpion <= this.fuelConsumption)
            {
                this.fuelQuantity -= consumpion;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            string carInfo =
                   $"Make: {this.Make}\r\n" +
                   $"Model: {this.Model}\r\n" +
                   $"Year: {this.Year}\r\n" +
                   $"Fuel: {this.fuelQuantity:f2}L";
            return carInfo;
        }
    }
}

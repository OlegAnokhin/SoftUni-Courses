using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int batteries) : base(model, color)
        {
            this.Batteries = batteries; // Battery
        }
        public int Batteries { get; private set; }
        //public override string Start()
        //{
        //    return "Start from Tesla";
        //}
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{base.ToString()} with {this.Batteries} batteries");
            result.AppendLine(this.Start());
            result.AppendLine(this.Stop());
            return result.ToString().TrimEnd();
        }
    }
}

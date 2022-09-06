using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int ApBedCapacity = 6;
        public Apartment() : base(ApBedCapacity)
        {
        }
    }
}

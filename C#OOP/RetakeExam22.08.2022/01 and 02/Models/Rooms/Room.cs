using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight = 0;

        protected Room(int bedCapacity)
        {
           this.BedCapacity = bedCapacity;
           this.pricePerNight = 0;
        }
        public int BedCapacity { get; set; }
        public double PricePerNight
        {
            get
            {
                return pricePerNight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight = value;
            }
        }
        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}

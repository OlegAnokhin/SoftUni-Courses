using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }
        public IRoom Room { get; set; }
        public int ResidenceDuration
        {
            get
            {
                return residenceDuration;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get
            {
                return adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get
            {
                return childrenCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }
        public int BookingNumber { get; set; }
        public string BookingSummary()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():f2} $");
            return sb.ToString().TrimEnd();
        }
        public double TotalPaid()
        {
            return Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
        }
    }
}
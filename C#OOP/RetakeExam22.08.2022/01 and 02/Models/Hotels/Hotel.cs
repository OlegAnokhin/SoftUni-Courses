using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover = 0;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }
        public int Category
        {
            get
            {
                return category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double sum = 0;
                foreach (var booking in this.Bookings.All())
                {
                    Booking currBooking = (Booking)booking;
                    sum += currBooking.TotalPaid();
                }
                return sum;
            }
        }

        public IRepository<IRoom> Rooms
        {
            get
            {
               return this.rooms;
            }
            set
            {
                this.rooms = value;
            }
        }
        public IRepository<IBooking> Bookings
        {
            get
            {
                return this.bookings;
            }
            set
            {
                this.bookings = value;
            }
        }
    }
}
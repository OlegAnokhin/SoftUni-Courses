using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            Hotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var currHotel = hotels.Select(hotelName);
            if (currHotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = currHotel;
            var currRoom = hotel.Rooms.Select(roomTypeName);
            if (currRoom != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            IRoom room = null;
            if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var currHotel = hotels.Select(hotelName);
            if (currHotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            var currRoom = currHotel.Rooms.Select(roomTypeName);
            if (currRoom == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }
            IHotel hotel = currHotel;
            IRoom room = currRoom;
            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }
        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = hotels.All().OrderBy(n => n.FullName);
            int guestCount = adults + children;
            if (orderedHotels.Any(c => c.Category == category))
            {
                foreach (var hotel in orderedHotels)
                {
                    if (hotel.Category != category)
                    {
                        continue;
                    }
                    var avaliableRooms = hotel.Rooms
                        .All()
                        .Where(pr => pr.PricePerNight > 0)
                        .OrderBy(bc => bc.BedCapacity);
                    if (avaliableRooms.Any(b => b.BedCapacity >= guestCount))
                    {
                        foreach (var room in avaliableRooms)
                        {
                            if (room.BedCapacity >= guestCount)
                            {
                                int bookingNumber = hotel.Bookings.All().Count + 1;
                                Booking booking = new Booking(room, duration, adults, children, bookingNumber);
                                hotel.Bookings.AddNew(booking);
                                return $"{string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName)}";
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                return $"{string.Format(OutputMessages.CategoryInvalid, category)}";
            }
            return OutputMessages.RoomNotAppropriate;
        }
        public string HotelReport(string hotelName)
        {
            var sb = new StringBuilder();
            var currHotel = hotels.Select(hotelName);
            if (currHotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = currHotel;
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine($"--Bookings:");
                sb.AppendLine();
                sb.AppendLine("none");
            }
            else
            {
                sb.AppendLine($"--Bookings:");
                sb.AppendLine();
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }
            return sb.ToString().Trim();
        }
    }
}
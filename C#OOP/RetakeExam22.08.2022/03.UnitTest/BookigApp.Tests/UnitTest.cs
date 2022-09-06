using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHotelConstructor()
        {
            Hotel hotel = new Hotel("hotel", 1);
            Assert.AreEqual("hotel", hotel.FullName);
            Assert.AreEqual(1, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Rooms.Count);
        }
        [Test]
        public void TestHotelNameThrowExc()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 1));
        }
        [Test]
        public void TestHotelCategoryThrowExc()
        {
            Assert.Throws<ArgumentException>(() => new Hotel("hotel", 0));
            Assert.Throws<ArgumentException>(() => new Hotel("hotel", 10));
        }
        [Test]
        public void TestAddRoom()
        {
            Hotel hotel = new Hotel("hotel", 1);
            Room room = new Room(2, 5.5);
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
        }
        [Test]
        public void TestBookRoom()
        {
            Hotel hotel = new Hotel("hotel", 1);
            Room room = new Room(10, 5.5);
            hotel.AddRoom(room);
            hotel.BookRoom(2,2,2,20000);
            Assert.AreEqual(1, hotel.Bookings.Count);
        }
        [Test]
        public void TestBookRoomThrowExc()
        {
            Hotel hotel = new Hotel("hotel", 1);
            Room room = new Room(1, 5.5);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 2, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 2, 2, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -2, 2, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, -2, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, -2, 0));
        }
        [Test]
        public void TestRoomThrowExc()
        {
            Assert.Throws<ArgumentException>(() => new Room(0, 5.5));
            Assert.Throws<ArgumentException>(() => new Room(2, 0));
        }
        [Test]
        public void TestRoomBedCap()
        {
            Room room = new Room(1, 5);
            Assert.AreEqual(1, room.BedCapacity);
            Assert.AreEqual(5, room.PricePerNight);
        }
        [Test]
        public void NotEnoughBedsShouldIgnore()
        {
            Hotel hotel = new Hotel("hotel", 1);
            hotel.AddRoom(new Room(1, 5));
            hotel.BookRoom(3, 2, 2, 300);
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
        }
        [Test]
        public void NotEnoughBudgetShouldIgnore()
        {
            Hotel hotel = new Hotel("hotel", 1);
            hotel.AddRoom(new Room(1, 200));
            hotel.BookRoom(1, 0, 3, 50);
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
        }
        [TestCase(0)]
        [TestCase(-10)]
        public void TestRoomBedTrow(int bets)
        {
            Assert.Throws<ArgumentException>(() => new Room(bets, 5));
        }
        [TestCase(0)]
        [TestCase(-10)]
        public void TestRoomPricePerNightTrow(double price)
        {
            Assert.Throws<ArgumentException>(() => new Room(5, price));
        }
        [Test]
        public void TestBookingConstr()
        {
            Room room = new Room(4, 5);
            Booking booking = new Booking(2, room, 2);
            Assert.AreEqual(2, booking.BookingNumber);
            Assert.AreEqual(4, booking.Room.BedCapacity);
            Assert.AreEqual(5, booking.Room.PricePerNight);
            Assert.AreEqual(2, booking.ResidenceDuration);
        }
    }
}


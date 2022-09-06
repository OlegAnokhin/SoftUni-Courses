using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels;
        public HotelRepository()
        {   
            this.hotels = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }
        public IHotel Select(string criteria)
        {
            return hotels.FirstOrDefault(n => n.FullName == criteria);
        }
        public IReadOnlyCollection<IHotel> All() => hotels;
    }
}
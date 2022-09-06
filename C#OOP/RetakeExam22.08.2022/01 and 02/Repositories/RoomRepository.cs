using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;
        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }
        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(r => r.GetType().Name == criteria);
        }
        public IReadOnlyCollection<IRoom> All() => rooms;
        //{
        //    IReadOnlyCollection<IRoom> result = this.rooms;
        //    return result;
        //}
    }
}
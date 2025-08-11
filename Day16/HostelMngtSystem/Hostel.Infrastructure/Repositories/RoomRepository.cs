using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        //public int _id = 1;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.RoomId == id);
        }

        public void Add(Room room)
        {
            //room.RoomId = _id++;
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }
    }
}

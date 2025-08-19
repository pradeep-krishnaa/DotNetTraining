using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


using Hostel.Core.Entities;
using Hostel.Infrastructure.Data;

namespace Hostel.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task AddAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Room?> GetFirstRoomWithSpaceAsync()
        {
            return await _context.Rooms
                .Where(r => _context.Students.Count(s => s.RoomId == r.RoomId) < r.Capacity)
                .OrderBy(r => r.RoomId)
                .FirstOrDefaultAsync();
        }
    }
}

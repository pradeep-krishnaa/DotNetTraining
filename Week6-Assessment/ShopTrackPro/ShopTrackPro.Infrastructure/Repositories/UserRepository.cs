using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User User)
        {
            _context.Users.Update(User);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User != null)
            {
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}

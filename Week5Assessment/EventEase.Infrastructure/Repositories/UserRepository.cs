using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using EventEase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository

    {
        //private readonly List<User> _users = new List<User>();
        //public int _nextId = 1;
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        //public List<User> GetAll()
        //{
        //    return _users;
        //}
        //public User GetById(int id)
        //{
        //    return _users.FirstOrDefault(u => u.Id == id);
        //}
        //public void Add(User entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    entity.Id = _nextId++;
        //    _users.Add(entity);
        //}
        //public void Update(User entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    var existingUser = GetById(entity.Id);
        //    if (existingUser == null) throw new KeyNotFoundException($"User with ID {entity.Id} not found");
        //    existingUser.Name = entity.Name;
        //    existingUser.Email = entity.Email;

        //}
        //public void Delete(User entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    var existingUser = GetById(entity.Id);
        //    if (existingUser == null) throw new KeyNotFoundException($"User with ID {entity.Id} not found");
        //    _users.Remove(existingUser);
        //}

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            await _context.SaveChangesAsync();
        }
    }
}

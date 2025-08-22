using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using EventEase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationEase.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        //private readonly List<Registration> _registrations = new List<Registration>();
        //public int _nextid = 1;
        //public List<Registration> GetAll()
        //{
        //    return _registrations;
        //}
        //public Registration GetById(int id)
        //{
        //    return _registrations.FirstOrDefault(r => r.Id == id);
        //}
        //public void Add(Registration entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    entity.Id = _nextid++;
        //    _registrations.Add(entity);
        //}
        //public void Update(Registration entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    var existingRegistration = GetById(entity.Id);
        //    if (existingRegistration == null) throw new KeyNotFoundException($"Registration with ID {entity.Id} not found");
        //    existingRegistration.UserId = entity.UserId;
        //    existingRegistration.RegistrationId = entity.RegistrationId;
        //    existingRegistration.RegistrationDate = entity.RegistrationDate;



        //}
        //public void Delete(Registration entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    var existingRegistration = GetById(entity.Id);
        //    if (existingRegistration == null) throw new KeyNotFoundException($"Registration with ID {entity.Id} not found");
        //    _registrations.Remove(existingRegistration);
        //}

        //public List<Registration> GetRegistrationsByRegistrationId(int id)
        //{
        //    List<Registration> registrations = new List<Registration>();
        //    foreach(var registration in _registrations)
        //    {
        //        if(registration.RegistrationId==id)
        //        {
        //            registrations.Add(registration);
        //        }
        //    }
        //    return registrations;
        //}

        private readonly AppDbContext _context;

        public RegistrationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Registration>> GetAllAsync()
        {
            return await _context.Registrations.ToListAsync();

        }

        public async Task<Registration> GetByIdAsync(int id)
        {
            return await _context.Registrations.FindAsync(id);
        }

        public async Task AddAsync(Registration user)
        {
            _context.Registrations.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Registration user)
        {
            _context.Registrations.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Registrations.Remove(_context.Registrations.Find(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Registration>> GetRegistrationsByEventIdAsync(int id)
        {
            List<Registration> registrations = new List<Registration>();
            var registrationss = await _context.Registrations.ToListAsync();
            foreach (var registration in registrationss)
            {
                if (registration.EventId == id)
                {
                    registrations.Add(registration);
                }
            }
            return registrations;
        }
    }
}

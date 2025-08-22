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
    public class EventRepository : IEventRepository
    {
        //private readonly List<Event> _events = new List<Event>();
        //public int _nextId = 1;
        //public List<Event> GetAll()
        //{
        //    return _events;
        //}
        //public Event GetById(int id)
        //{
        //    return _events.FirstOrDefault(e => e.Id == id);
        //}
        //public void Add(Event entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    entity.Id = _nextId++;
        //    _events.Add(entity);
        //}
        //public void Update(Event entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    var existingEvent = GetById(entity.Id);
        //    if (existingEvent == null) throw new KeyNotFoundException($"Event with ID {entity.Id} not found");
        //    existingEvent.Title = entity.Title;
        //    existingEvent.Description = entity.Description;
        //    existingEvent.Date = entity.Date;
        //    existingEvent.Location = entity.Location;

        //}
        //public void Delete(Event entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));
        //    var existingEvent = GetById(entity.Id);
        //    if (existingEvent == null) throw new KeyNotFoundException($"Event with ID {entity.Id} not found");
        //    _events.Remove(existingEvent);
        //}

        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Event.ToListAsync();

        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Event.FindAsync(id);
        }

        public async Task AddAsync(Event user)
        {
            _context.Event.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event user)
        {
            _context.Event.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Event.Remove(_context.Event.Find(id));
            await _context.SaveChangesAsync();
        }
    }
}

using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly List<Registration> _registrations = new List<Registration>();
        public int _nextid = 1;
        public List<Registration> GetAll()
        {
            return _registrations;
        }
        public Registration GetById(int id)
        {
            return _registrations.FirstOrDefault(r => r.Id == id);
        }
        public void Add(Registration entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entity.Id = _nextid++;
            _registrations.Add(entity);
        }
        public void Update(Registration entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var existingRegistration = GetById(entity.Id);
            if (existingRegistration == null) throw new KeyNotFoundException($"Registration with ID {entity.Id} not found");
            existingRegistration.UserId = entity.UserId;
            existingRegistration.EventId = entity.EventId;
            existingRegistration.RegistrationDate = entity.RegistrationDate;



        }
        public void Delete(Registration entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var existingRegistration = GetById(entity.Id);
            if (existingRegistration == null) throw new KeyNotFoundException($"Registration with ID {entity.Id} not found");
            _registrations.Remove(existingRegistration);
        }

        public List<Registration> GetRegistrationsByEventId(int id)
        {
            List<Registration> registrations = new List<Registration>();
            foreach(var registration in _registrations)
            {
                if(registration.EventId==id)
                {
                    registrations.Add(registration);
                }
            }
            return registrations;
        }
    }
}

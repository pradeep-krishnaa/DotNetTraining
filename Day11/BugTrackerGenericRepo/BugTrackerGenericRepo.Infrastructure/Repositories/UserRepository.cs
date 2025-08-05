using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;

namespace BugTrackerGenericRepo.Infrastructure.Repositories
{
    public  class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        public void Add(User entity)
        {
            _users.Add(entity);
        }
        public void Update(User entity)
        {
            var existingUser = GetById(entity.UserId);
            if (existingUser != null)
            {
                existingUser.UserId = entity.UserId;
                existingUser.UserName = entity.UserName;
            }
        }
        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.UserId == id);
        }
        public List<User> GetAll()
        {
            return _users;
        }
    }
}

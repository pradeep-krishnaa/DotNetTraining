using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;
using BugTrackerGenericRepo.Infrastructure.Repositories;

namespace BugTrackerGenericRepo.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(User user)
        {
            _userRepository.Add(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }
        public User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}

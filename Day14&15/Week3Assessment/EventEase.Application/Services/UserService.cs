using EventEase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;

namespace EventEase.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        //public int _nextUserId = 1; 
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void CreateUser(UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null) throw new ArgumentNullException(nameof(userRequestDTO));
            var user = _mapper.Map<User>(userRequestDTO);
            _userRepository.Add(user);
        }
        public void UpdateUser(int userId, UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null) throw new ArgumentNullException(nameof(userRequestDTO));
            var existingUser = _userRepository.GetById(userId);
            if (existingUser == null) throw new KeyNotFoundException($"User with ID {userId} not found");
            var user = _mapper.Map(userRequestDTO, existingUser);
            _userRepository.Update(user);
        }
        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null) throw new KeyNotFoundException($"User with ID {userId} not found");
            _userRepository.Delete(user);
        }
        public UserResponseDTO GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null) throw new KeyNotFoundException($"User with ID {userId} not found");
            return _mapper.Map<UserResponseDTO>(user);
        }
        public List<UserResponseDTO> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserResponseDTO>>(users);

        }
    }
}

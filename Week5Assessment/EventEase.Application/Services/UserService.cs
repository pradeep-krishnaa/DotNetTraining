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
        public async Task CreateUserAsync(UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null) throw new ArgumentNullException(nameof(userRequestDTO));
            var user = _mapper.Map<User>(userRequestDTO);
            await _userRepository.AddAsync(user);
        }
        public async Task UpdateUserAsync(int userId, UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null) throw new ArgumentNullException(nameof(userRequestDTO));
            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null) throw new KeyNotFoundException($"User with ID {userId} not found");
            _mapper.Map(userRequestDTO, existingUser);
            await _userRepository.UpdateAsync(existingUser);
        }
        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException($"User with ID {userId} not found");
            await _userRepository.DeleteAsync(userId);
        }
        public async Task<UserResponseDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException($"User with ID {userId} not found");
            return _mapper.Map<UserResponseDTO>(user);
        }
        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return  _mapper.Map<List<UserResponseDTO>>(users);

        }
    }
}

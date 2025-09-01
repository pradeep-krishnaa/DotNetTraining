using AutoMapper;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<UserResponseDTO>>(users);
        }

        public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserResponseDTO?>(user);
        }

        public async Task AddUserAsync(UserRequestDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            //user.PasswordHash = HashPassword(dto.Password);
            await _repository.AddAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserRequestDTO dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return;

            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.Role = dto.Role;
            //user.PasswordHash = HashPassword(dto.Password);

            await _repository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id) =>
            await _repository.DeleteAsync(id);

        //private string HashPassword(string password)
        //{
        //    using var sha = SHA256.Create();
        //    var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    return Convert.ToBase64String(bytes);
        //}
    }
}

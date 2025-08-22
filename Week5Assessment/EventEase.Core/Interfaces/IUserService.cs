using EventEase.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(UserRequestDTO UserRequestDTO);
        Task UpdateUserAsync(int UserId, UserRequestDTO UserRequestDTO);
        Task DeleteUserAsync(int UserId);
        Task<UserResponseDTO> GetUserByIdAsync(int UserId);
        Task<List<UserResponseDTO>> GetAllUsersAsync();


    }
}

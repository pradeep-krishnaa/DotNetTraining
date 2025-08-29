using ShopTrackPro.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO?> GetUserByIdAsync(int id);
        Task AddUserAsync(UserRequestDTO User);
        Task UpdateUserAsync(int id, UserRequestDTO User);
        Task DeleteUserAsync(int id);
    }
}

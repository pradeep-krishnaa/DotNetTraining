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
        void CreateUser(UserRequestDTO userRequestDTO);
        void UpdateUser(int userId, UserRequestDTO userRequestDTO);
        void DeleteUser(int userId);
        UserResponseDTO GetUserById(int userId);
        List<UserResponseDTO> GetAllUsers();


    }
}

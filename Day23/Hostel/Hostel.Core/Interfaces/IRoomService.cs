using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomResponseDTO>> GetAllRoomsAsync();
        Task<RoomResponseDTO?> GetRoomByIdAsync(int id);
        Task AddRoomAsync(RoomRequestDTO room);
        Task UpdateRoomAsync(int id ,RoomRequestDTO room);
        Task DeleteRoomAsync(int id);
    }
}

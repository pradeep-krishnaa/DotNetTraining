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
        Room CreateRoom(RoomRequestDTO roomRequestDTO);
        RoomResponseDTO GetRoomById(int id);
        List<RoomResponseDTO> GetAllRooms();
    }
}

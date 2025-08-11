using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.DTOs
{
    public class StaffResponseDTO
    {
        public int StaffId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ManagedRoomCount { get; set; }
        public List<RoomInfoDTO> AssignedRooms { get; set; } = new List<RoomInfoDTO>();
    }
}

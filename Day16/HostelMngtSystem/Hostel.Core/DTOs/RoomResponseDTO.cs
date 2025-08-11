using Hostel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.DTOs
{
    public class RoomResponseDTO
    {
        public int RoomId { get; set; }
        public int Capacity { get; set; }
        public string AssignedStaff { get; set; }

    }
}

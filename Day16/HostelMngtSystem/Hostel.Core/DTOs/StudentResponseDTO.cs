using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.DTOs
{
    public class StudentResponseDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int RoomNumber { get; set; }
        public string StaffName { get; set; } = string.Empty;
    }
}

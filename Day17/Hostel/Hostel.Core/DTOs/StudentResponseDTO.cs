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
        public string StudentName { get; set; }
        public string StudentDepartment {  get; set; }
        public int RoomId { get; set; }
    }
}

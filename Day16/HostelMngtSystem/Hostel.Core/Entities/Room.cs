using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.Entities
{
    public class Room
    {
        
        public int RoomId { get; set; }
        public int Capacity { get; set; }

        // Foreign Key - Staff managing this room
        public int StaffId { get; set; }
        public Staff Staff { get; set; } = null!;
            
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

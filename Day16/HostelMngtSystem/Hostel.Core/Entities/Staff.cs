using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RoomsAllocated { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        // Foreign Key
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
    }
}

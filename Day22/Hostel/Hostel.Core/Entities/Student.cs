using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.Entities
{
    public class Student
    {
        //id , name , dept , roomid , staffid
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentDepartment { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}

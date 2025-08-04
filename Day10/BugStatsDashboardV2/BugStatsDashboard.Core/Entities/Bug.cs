using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatsDashboard.Core.Entities
{
    public class Bug
    {
        public int BugId { get; set; }
        public required string BugTitle { get; set; }

        public int ProjectId { get; set; }
        public required Project Project { get; set; } // Navigation property to the Project entity
        public int AssignedUserId { get; set; } 
        public required User AssignedUser { get; set; }  // Navigation property to the User entity
        public required string Status { get; set; } //  Open, In Progress, Closed
        public required string Priority { get; set; } //  Low, Medium, High
        public DateTime CreatedAt { get; set; } // when bug was created




    }
}

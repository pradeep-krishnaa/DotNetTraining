using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatsDashboard.Infrastructure.DTOs
{
    public class BugDTO
    {
        public string Title { get; set; } 
        public string ProjectName { get; set; }
        public string AssignedUserName { get; set; }
        public string Status { get; set; } // Open, In Progress, Closed
        public string Priority { get; set; } // Low, Medium, High
    }
}

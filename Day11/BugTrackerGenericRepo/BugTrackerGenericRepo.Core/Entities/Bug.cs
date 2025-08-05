using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerGenericRepo.Core.Entities
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // e.g., "Open", "In Progress", "Closed"
        public string Priority { get; set; } // e.g., "Low", "Medium", "High"

    }
}

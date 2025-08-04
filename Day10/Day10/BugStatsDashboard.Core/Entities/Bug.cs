using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatsDashboard.Core.Entities
{
    public class Bug
    {
        public int Id { get; set; } = 0;
        //dont to allow null values in Title, ProjectName, Priority, Status, CreatedBy

        public string Title { get; set; }
        public string ProjectName { get; set; } // Name of the project the bug is associated with
        public string Priority { get; set; }// "High" , "Medium" , "Low"
        public string Status { get; set; } // "Open" , "In Progress", "Closed"
        public string CreatedBy { get; set; }// Username of the person who created the bug




        public DateTime CreatedOn { get; set; }  // cant be n
    }
}

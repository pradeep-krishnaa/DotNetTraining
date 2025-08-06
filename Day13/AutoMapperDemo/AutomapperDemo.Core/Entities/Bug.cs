using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperDemo.Core.Entities
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //open , closed , in progress
        public DateTime CreatedDate { get; set; }
        public int? ProjectId { get; set; }   //nullable
        public DateTime? DueDate { get; set; }

    }
}

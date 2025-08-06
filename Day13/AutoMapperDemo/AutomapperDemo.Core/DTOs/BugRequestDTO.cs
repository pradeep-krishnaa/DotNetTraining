using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperDemo.Core.DTOs
{
    public class BugRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //open , closed , in progress
        public DateTime DueDate { get; set; }
    }
}

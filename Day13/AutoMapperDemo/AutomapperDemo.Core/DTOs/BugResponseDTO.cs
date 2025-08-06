using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperDemo.Core.DTOs
{
    public class BugResponseDTO
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; } //open , closed , in progress
        public DateTime DueDate { get; set; }
    }
}

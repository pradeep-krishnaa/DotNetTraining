using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatsDashboard.Infrastructure.DTOs
{
    public class GroupStatsDTO
    {
        public string Key { get; set; } = string.Empty; // This could be a date, priority, or user name
        public int Count { get; set; }
    }
}

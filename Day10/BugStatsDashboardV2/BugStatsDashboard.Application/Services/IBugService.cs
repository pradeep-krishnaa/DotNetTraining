using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;
using BugStatsDashboard.Infrastructure.DTOs;


namespace BugStatsDashboard.Application.Services
{
    public interface IBugService
    {
        List<BugDTO> ViewAllBugs();
        List<BugDTO> ViewBugsByProject(); 
        List<BugDTO> ViewBugsByStatus();
        List<BugDTO> ViewBugsByPriority();
        List<GroupStatsDTO> ShowCountByCreatedDate();
        List<GroupStatsDTO > ShowCountByPriority();
        List<GroupStatsDTO> ShowCountByUser();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;
using BugStatsDashboard.Core.Interfaces;
using BugStatsDashboard.Infrastructure.Repositories;


namespace BugStatsDashboard.Application.Services
{
    public class BugStatsService
    {
        private readonly IBugRepository _bugRepository;
        public BugStatsService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public void ShowBugCountByStatus()
        {
            var bugs = _bugRepository.GetAllBugs();
            var statusCount = bugs.GroupBy(b => b.Status)
                                  .Select(g => new { Status = g.Key, Count = g.Count() });
            Console.WriteLine("Bug Count by Status:");
            foreach (var status in statusCount)
            {
                Console.WriteLine($"{status.Status}: {status.Count}");
            }
        }

        public void ShowBugCountByProjectAndPriority()
        {
            var bugs = _bugRepository.GetAllBugs();
            var projectPriorityCount = bugs.GroupBy(b => new { b.ProjectName, b.Priority })
                                           .Select(g => new { g.Key.ProjectName, g.Key.Priority, Count = g.Count() });
            Console.WriteLine("Bug Count by Project and Priority:");
            foreach (var item in projectPriorityCount)
            {
                Console.WriteLine($"{item.ProjectName} - {item.Priority}: {item.Count}");
            }
        }
        public void ShowDailyBugReport()
        {
            var bugs = _bugRepository.GetAllBugs();
            var dailyReport = bugs.GroupBy(b => b.CreatedOn.Date)
                                  .Select(g => new { Date = g.Key, Count = g.Count() });
            Console.WriteLine("Daily Bug Report:");
            foreach (var report in dailyReport)
            {
                Console.WriteLine($"{report.Date.ToShortDateString()}: {report.Count}");
            }
        }

        public void ShowTopCreators()
        {
            var bugs = _bugRepository.GetAllBugs();
            var topCreators = bugs.GroupBy(b => b.CreatedBy)
                                  .Select(g => new { Creator = g.Key, Count = g.Count() })
                                  .OrderByDescending(g => g.Count)
                                  .Take(5);
            Console.WriteLine("Top 5 Bug Creators:");
            foreach (var creator in topCreators)
            {
                Console.WriteLine($"{creator.Creator}: {creator.Count}");
            }
        }

    }
}

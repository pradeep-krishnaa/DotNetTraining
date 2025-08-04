using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;
using BugStatsDashboard.Core.Interfaces;
using BugStatsDashboard.Infrastructure.Repositories;
using BugStatsDashboard.Infrastructure.DTOs;

namespace BugStatsDashboard.Application.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;
        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }
        

        public List<BugDTO> ViewAllBugs()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.Select(b => new BugDTO
            {
                Title = b.BugTitle,
                ProjectName = b.Project.ProjectName,
                AssignedUserName = b.AssignedUser.UserName,
                Status = b.Status,
                Priority = b.Priority
            }).ToList();
        }

        public List<BugDTO> ViewBugsByProject()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.GroupBy(b => b.Project.ProjectName)
                       .Select(g => new BugDTO
                       {
                           ProjectName = g.Key,
                           Title = string.Join(", ", g.Select(b => b.BugTitle)),
                           AssignedUserName = string.Join(", ", g.Select(b => b.AssignedUser.UserName)),
                           Status = string.Join(", ", g.Select(b => b.Status)),
                           Priority = string.Join(", ", g.Select(b => b.Priority))
                       }).ToList();
        }

        public List<BugDTO> ViewBugsByStatus()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.GroupBy(b => b.Status)
                       .Select(g => new BugDTO
                       {
                           Status = g.Key,
                           Title = string.Join(", ", g.Select(b => b.BugTitle)),
                           ProjectName = string.Join(", ", g.Select(b => b.Project.ProjectName)),
                           AssignedUserName = string.Join(", ", g.Select(b => b.AssignedUser.UserName)),
                           Priority = string.Join(", ", g.Select(b => b.Priority))
                       }).ToList();
        }

        public List<BugDTO> ViewBugsByPriority()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.GroupBy(b => b.Priority)
                       .Select(g => new BugDTO
                       {
                           Priority = g.Key,
                           Title = string.Join(", ", g.Select(b => b.BugTitle)),
                           ProjectName = string.Join(", ", g.Select(b => b.Project.ProjectName)),
                           AssignedUserName = string.Join(", ", g.Select(b => b.AssignedUser.UserName)),
                           Status = string.Join(", ", g.Select(b => b.Status))
                       }).ToList();
        }

        public List<GroupStatsDTO> ShowCountByCreatedDate()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.GroupBy(b => b.CreatedAt.Date)
                       .Select(g => new GroupStatsDTO
                       {
                           Key = g.Key.ToString("yyyy-MM-dd"),
                           Count = g.Count()
                       }).ToList();
        }

        public List<GroupStatsDTO> ShowCountByPriority()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.GroupBy(b => b.Priority)
                       .Select(g => new GroupStatsDTO
                       {
                           Key = g.Key,
                           Count = g.Count()
                       }).ToList();
        }

        public List<GroupStatsDTO> ShowCountByUser()
        {
            var bugs = _bugRepository.GetAllBugs();
            return bugs.GroupBy(b => b.AssignedUser.UserName)
                       .Select(g => new GroupStatsDTO
                       {
                           Key = g.Key,
                           Count = g.Count()
                       }).ToList();
        }

    }
}

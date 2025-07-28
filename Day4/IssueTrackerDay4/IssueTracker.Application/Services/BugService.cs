using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;
using IssueTracker.Infrastructure.Repositories;

namespace IssueTracker.Application.Services
{
    public class BugService
    {
        private readonly IBugRepository _bugRepository;
        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }


        public void CreateBug(string title, string description)
        {
            var bug = new Bug
            {
                Title = title,
                Description = description,
                Status = "Open" 
            };
            _bugRepository.AddBug(bug);
        }


        public List<Bug> GetAllBugs() => _bugRepository.GetAllBugs();
        
        //public void AddBug(Bug bug)
        //{
        //    _bugRepository.AddBug(bug);
        //}
        //public Bug GetBugById(int id)
        //{
        //    return _bugRepository.GetBugById(id);
        //}
        //public void UpdateBug(Bug bug)
        //{
        //    _bugRepository.UpdateBug(bug);
        //}
        //public void DeleteBug(int id)
        //{
        //    _bugRepository.DeleteBug(id);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Core.Interfaces; 
using IssueTracker.Core.Entities;


namespace IssueTracker.Application.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;
        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public void CreateBug(string title, string description)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                
                throw new ArgumentNullException("Title cannot be null");
            }
            if(string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("Description cannot be null");
            }
            var bug = new Bug
            {
                Title = title,
                Description = description,
                Status = "Open"
            };
            _bugRepository.AddBug(bug);
        }


        public List<Bug> GetAllBugs()
        {
            return _bugRepository.GetAllBugs();
        }

        public Bug GetBugById(int id)
        {
            var bug = _bugRepository.GetBugById(id);
            if (bug == null)
            {
                throw new KeyNotFoundException($"Bug with ID {id} not found.");
            }
            return bug;
        }

        public void UpdateBug(int id, string newTitle, string newStatus)
        {
            var bug = _bugRepository.GetBugById(id);
            if (bug == null)
            {
                throw new KeyNotFoundException($"Bug with ID {id} not found.");
            }
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentNullException("New title cannot be null");
            }
            bug.Title = newTitle;
            bug.Status = newStatus;
            _bugRepository.UpdateBug(bug);
        }

        public void DeleteBug(int id)
        {
            var bug = _bugRepository.GetBugById(id);
            if (bug == null)
            {
                throw new KeyNotFoundException($"Bug with ID {id} not found.");
            }
            _bugRepository.DeleteBug(id);
        }
    }
}

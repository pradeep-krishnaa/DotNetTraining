using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;

namespace IssueTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = new List<Bug>();
        private static int _nextId = 1;

        //implement all methods of IBugRepository interface
        public List<Bug> GetAllBugs()
        {
            return _bugs;
        }

        public Bug GetBugById(int id)
        {
            return _bugs.FirstOrDefault(b => b.Id == id);
        }

        public void AddBug(Bug bug)
        {
            bug.Id = _nextId++;
            _bugs.Add(bug);
        }

        public void UpdateBug(Bug bug)
        {
            var index = _bugs.FindIndex(b => b.Id == bug.Id);
            if (index != -1)
            {
                _bugs[index] = bug;
            }
        }

        public void DeleteBug(int id)
        {
            var bug = GetBugById(id);
            if (bug != null)
            {
                _bugs.Remove(bug);
            }
        }


    }
}

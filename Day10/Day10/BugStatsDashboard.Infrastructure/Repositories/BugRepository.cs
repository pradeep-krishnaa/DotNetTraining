using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;
using BugStatsDashboard.Core.Interfaces;

namespace BugStatsDashboard.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs;
        public BugRepository()
        {
            _bugs = new List<Bug>
            {
                new Bug { Id = 1, Title = "Bug 6", ProjectName = null , Priority = "High", Status = "Open", CreatedBy = "User1", CreatedOn = new DateTime(2023, 10, 1, 12, 0, 0) },
                new Bug { Id = 1, Title = "Bug 1", ProjectName = "Project A", Priority = "High", Status = "Open", CreatedBy = "User1" , CreatedOn = new DateTime(2023, 10, 1, 12, 0, 0)  },
                new Bug { Id = 2, Title = "Bug 2", ProjectName = "Project B", Priority = "Medium", Status = "In Progress", CreatedBy = "User2" , CreatedOn = new DateTime(2023, 11, 1, 12, 0, 0) },
                new Bug { Id = 3, Title = "Bug 3", ProjectName = "Project C", Priority = "Low", Status = "Closed", CreatedBy = "User3" , CreatedOn = new DateTime(2023, 11, 1, 12, 0, 0)  },
                new Bug { Id = 4, Title = "Bug 4", ProjectName = "Project D", Priority = "High", Status = "Open", CreatedBy = "User4" , CreatedOn = new DateTime(2023, 10, 1, 12, 0, 0)  },
                new Bug { Id = 5, Title = "Bug 5", ProjectName = "Project E", Priority = "Medium", Status = "In Progress", CreatedBy = "User5" , CreatedOn = new DateTime(2023, 11, 1, 12, 0, 0)  }
            };
        }

        public List<Bug> GetAllBugs()
        {
            return _bugs;
        }
        public Bug GetBugById(int id)
        {
            return _bugs.FirstOrDefault(b => b.Id == id);
        }


    }

}

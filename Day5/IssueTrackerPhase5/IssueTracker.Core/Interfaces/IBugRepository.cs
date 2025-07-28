using IssueTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IBugRepository
    {
        //has CRUD operations
        List<Bug> GetAllBugs();
        Bug GetBugById(int id);
        void AddBug(Bug bug);
        void UpdateBug(Bug bug);
        void DeleteBug(int id);
    }
}

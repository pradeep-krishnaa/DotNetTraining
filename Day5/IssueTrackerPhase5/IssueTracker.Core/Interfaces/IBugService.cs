using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Core.Entities;

namespace IssueTracker.Core.Interfaces
{
    public interface IBugService
    {
        void CreateBug(string title , string description);
        List<Bug> GetAllBugs();
        Bug GetBugById(int id);
        void UpdateBug(int id , string newTitle , string newStatus);
        void DeleteBug(int id);



    }
}

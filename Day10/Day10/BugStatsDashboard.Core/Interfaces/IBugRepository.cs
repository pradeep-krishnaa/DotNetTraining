using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;

namespace BugStatsDashboard.Core.Interfaces
{
    public interface IBugRepository
    {
        List<Bug> GetAllBugs();
        Bug GetBugById(int id);
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerGenericRepo.Core.Entities;

namespace BugTrackerGenericRepo.Core.Interfaces
{
    public interface IBugRepository : IRepository<Bug>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;

namespace BugTrackerGenericRepo.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;

namespace LMS.Core.Interfaces
{
    public interface ILeaveRepository
    {
        List<Leave> GetAllLeaves();
        Leave GetLeaveById(int id);
        void AddLeave(Leave leave);
        void UpdateLeave(Leave leave);
        void DeleteLeave(int id);

    }
}

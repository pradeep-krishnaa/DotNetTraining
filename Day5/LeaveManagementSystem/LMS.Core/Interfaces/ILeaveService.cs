using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;

namespace LMS.Core.Interfaces
{
    public interface ILeaveService
    {
        void CreateLeave(string employeeName, DateTime startDate, DateTime endDate, string reason);
        List<Leave> GetAllLeaves();

        Leave GetLeaveById(int id);
        void UpdateLeave(int id, string newemployeeName, DateTime newstartDate, DateTime newendDate, string newreason);
        void DeleteLeave(int id);
    }
}

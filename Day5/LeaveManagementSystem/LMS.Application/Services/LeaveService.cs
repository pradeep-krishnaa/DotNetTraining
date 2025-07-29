using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;   //add project ref -> Core

namespace LMS.Application.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepository;
        public LeaveService(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public void CreateLeave(string employeeName, DateTime startDate, DateTime endDate, string reason)
        {
            var leave = new Leave
            {
                EmployeeName = employeeName,
                StartDate = startDate,
                EndDate = endDate,
                Reason = reason
            };
            _leaveRepository.AddLeave(leave);
        }

        public List<Leave> GetAllLeaves()
        {
            return _leaveRepository.GetAllLeaves();
        }

        public Leave GetLeaveById(int id)
        {
            return _leaveRepository.GetLeaveById(id);
        }

        public void UpdateLeave(int id, string newemployeeName, DateTime newstartDate, DateTime newendDate, string newreason)
        {
            var leave = _leaveRepository.GetLeaveById(id);
            if (leave != null)
            {
                leave.EmployeeName = newemployeeName;
                leave.StartDate = newstartDate;
                leave.EndDate = newendDate;
                leave.Reason = newreason;
                _leaveRepository.UpdateLeave(leave);
            }

        }
        public void DeleteLeave(int id)
        {
            _leaveRepository.DeleteLeave(id);
        }
    }
}

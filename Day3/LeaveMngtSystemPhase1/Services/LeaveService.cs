using System;

using LeaveMngtSystemPhase1.Models;
namespace LeaveMngtSystemPhase1.Services;
    public class LeaveService : ILeaveService
    {
        
        public void DisplayAll(List<LeaveRequest> leaveRequests)
        {
            foreach (var request in leaveRequests)
            {
                request.Display();
            }
        }

        public void ShowApprovals(List<IApprovable> approvables)
        {
            foreach (var approvable in approvables)
            {
                approvable.ShowApprovalStatus();
            }
        }
    }

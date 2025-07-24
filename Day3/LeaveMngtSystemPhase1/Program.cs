using System;

using LeaveMngtSystemPhase1.Models;
using LeaveMngtSystemPhase1.Services;
using System.Collections.Generic;
using System.Linq;

namespace LeaveMngtSystemPhase1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<LeaveRequest> leaveRequests = new List<LeaveRequest>();
            List<IApprovable> approvables = new List<IApprovable>();

            SickLeave sickLeave = new SickLeave(1, "John Doe", 5, "Medical Certificate");
            CasualLeave casualLeave = new CasualLeave(2, "Jane Smith", 3, "Family Emergency");

            leaveRequests.Add(sickLeave);
            leaveRequests.Add(casualLeave);
            approvables.Add(sickLeave);
            approvables.Add(casualLeave);

            
            ILeaveService leaveService = new LeaveService();

            leaveService.DisplayAll(leaveRequests);
            Console.WriteLine();

            leaveService.ShowAllApprovals(approvables);
            Console.WriteLine();


            sickLeave.Approve();
            casualLeave.Reject();

            leaveService.ShowAllApprovals(approvables);

        }
    }
}







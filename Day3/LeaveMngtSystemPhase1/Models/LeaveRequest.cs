using System;

namespace LeaveMngtSystemPhase1.Models;
public abstract class LeaveRequest
    {
        public int Id { get; set; }
        public string EmpName{ get; set; }
        public int DaysRequested { get; set; }
        public string Status { get; set; } = "Pending";

        public LeaveRequest(int id, string empName, int daysRequested)
        {
            Id = id;
            EmpName = empName;
            DaysRequested = daysRequested;
        }

        public void Approve() => Status = "Approved";
        public void Reject()
        {
            Status = "Rejected";
        }

        public abstract void Display();
        public abstract void ShowApprovalStatus();
    }

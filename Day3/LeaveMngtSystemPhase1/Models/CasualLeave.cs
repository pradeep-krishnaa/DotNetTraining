using System;

namespace LeaveMngtSystemPhase1.Models;

public class CasualLeave : LeaveRequest, IApprovable
{
    public string Reason { get; set; }
    public CasualLeave(int id, string empName, int daysRequested, string reason)
        : base(id, empName, daysRequested)
    {
        Reason = reason;
    }
    public override void Display()
    {
        Console.WriteLine($"Casual Leave Request: Id={Id}, Employee={EmpName}, Days Requested={DaysRequested}, Reason = {Reason}, Status={Status}");
    }
    public override void ShowApprovalStatus()
    {
        Console.WriteLine($"Casual Leave Request Status: {Status}");
    }
    
}
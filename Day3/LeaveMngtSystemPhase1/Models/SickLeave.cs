using System;

namespace LeaveMngtSystemPhase1.Models;

public class SickLeave : LeaveRequest, IApprovable
{
    public string DoctorNote { get; set; }
    public SickLeave(int id, string empName, int daysRequested, string doctornote)
        : base(id, empName, daysRequested)
    {
        DoctorNote = doctornote;
    }
    public override void Display()
    {
        Console.WriteLine($"Sick Leave Request: Id={Id}, Employee={EmpName}, Days Requested={DaysRequested}, Doctor Note : {DoctorNote}, Status={Status}");
    }
    public override void ShowApprovalStatus()
    {
        Console.WriteLine($"Sick Leave Request Status: {Status}");
    }
}
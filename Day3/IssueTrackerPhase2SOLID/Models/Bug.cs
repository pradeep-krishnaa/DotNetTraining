using System;

namespace IssueTrackerPhase2SOLID.Models;

public class Bug : Issue, IReportable
{
    public string Severity { get; set; }

    public string Status { get; set; } = "Open"; // Implementing the Status property from IReportable interface
    public Bug(int id, string title, string assignedTo, string severity)
        : base(id, title, assignedTo)
    {
        if (!IsValid)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(severity))
        {
            Console.WriteLine("Invalid Bug: Severity is required.");
            IsValid = false;
        }
        else
        {
            Severity = severity;
            IsValid = true;
        }
    }

    public override void Display()
    {
        Console.Write("[Bug] ");
        Console.WriteLine($"Severity: {Severity}");
    }

    public void ReportStatus()
    {
        Console.WriteLine($"Bug #{ID} is under investigation. Status: {Status}");
    }

    public void GetSummary()
    {
        Console.WriteLine($"Bug Summary: ID = {ID}, Title = {Title}, Assigned To = {AssignedTo}, Severity = {Severity} , Status: {Status}");
    }

    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Bug #{ID} status updated to: {Status}");
    }


}



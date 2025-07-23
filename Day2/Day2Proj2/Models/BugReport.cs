using System;

namespace Day2Proj2.Models;

public class BugReport : SupportTicket , IReportable
{
    public string Severity { get; set; }
    public BugReport(int id, string title, string description, string createdBy, string status, string severity)
        : base(id, title, description, createdBy, status)
    {
        Severity = severity;
    }

    public override void Display()
    {
        Console.WriteLine($"Bug #Id: {Id} , Title: {Title} , Desc: {Description} , CreatedBy: {CreatedBy} , Severity: {Severity}");
    }

    public void ReportStatus()
    {
        Console.WriteLine($"Bug Report Status: {Status}");
    }
}
using System;

namespace Day2Proj1Phase1.Models;

public class Bug : Issue , IReportable
{
    public string Severity { get; set; }
    public Bug(int id , string title , string assignedto , string severity) : base(id, title, assignedto)
    {
        Severity = severity;
    }
    public override void Display()
    {
        Console.Write("[Bug] ");
        base.Display();
        Console.WriteLine($"Severity: {Severity}");
    }

    public void ReportStatus()
    {
        Console.WriteLine($"Bug #{ID} is under investigation. Severity - {Severity}");
    }


}



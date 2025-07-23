using System;

using Day2Proj1Phase2.Models;
public class FeatureRequest : Issue , IReportable
{
    public string RequestedBy { get; set; }
    public string Status { get; set; } = "Open"; // Implementing the Status property from IReportable interface
    public string PlannedReleaseDate { get; set; }

    public FeatureRequest(int id, string title, string assignedTo, string requestedBy, string plannedReleaseDate)
        : base(id, title, assignedTo)
    {
        if (!IsValid)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(requestedBy) && string.IsNullOrWhiteSpace(plannedReleaseDate))
        {
            Console.WriteLine("Invalid FeatureRequest: RequestedBy and PlannedReleaseDate are required.");
            IsValid = false;
        }
        else if (string.IsNullOrWhiteSpace(requestedBy))
        {
            Console.WriteLine("Invalid FeatureRequest: RequestedBy is required.");
            IsValid = false;
        }
        else if (string.IsNullOrWhiteSpace(plannedReleaseDate))
        {
            Console.WriteLine("Invalid FeatureRequest: PlannedReleaseDate is required.");
            IsValid = false;
        }
        else
        {
            RequestedBy = requestedBy;
            PlannedReleaseDate = plannedReleaseDate;
            IsValid = true;
        }
    }


    public override void Display()
    {
        
        Console.Write("[Feature Request] ");
        base.Display();
        Console.WriteLine($"Requested By: {RequestedBy}, Planned Release Date: {PlannedReleaseDate}");
    }

    public void ReportStatus()
    {
        Console.WriteLine($"Feature Request #{ID} is under review. Status - {Status}");
    }

    public void GetSummary()
    {
        Console.WriteLine($"Feature Request Summary: ID = {ID}, Title = {Title}, Assigned To = {AssignedTo}, Requested By = {RequestedBy}, Planned Release Date = {PlannedReleaseDate}, Status = {Status}");
    }
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Feature Request #{ID} status updated to: {Status}");
    }
}
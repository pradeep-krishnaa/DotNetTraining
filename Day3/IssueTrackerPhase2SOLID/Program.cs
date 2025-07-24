using IssueTrackerPhase2SOLID.Models;
using IssueTrackerPhase2SOLID.Services;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<Issue> issues = new List<Issue>();

        // Hardcoded inputs for demonstration
        Bug bug = new Bug(1, "Login Bug", "Pradeep", "High");
        IssueTrackerPhase2SOLID.Models.Task task = new IssueTrackerPhase2SOLID.Models.Task(101, "Fixing Login Bug", "Krishnaa", 5);  // Invalid title
        FeatureRequest featureRequest = new FeatureRequest(1001, "New Login Feature", "Praven", "Product Team", "2023-12-31"); // Invalid assignedTo

        // Only add valid issues
        if (bug.IsValid) issues.Add(bug);
        if (task.IsValid) issues.Add(task);
        if (featureRequest.IsValid) issues.Add(featureRequest);
        Console.WriteLine("Creating Invalid Bug Object:");
        Bug invalidbug = new Bug(1, "Login Bug", "", "High");
        if (invalidbug.IsValid) issues.Add(bug);

        List<IReportable> reportables = new List<IReportable>();
        reportables.Add(bug);
        reportables.Add(task);
        reportables.Add(featureRequest);

        IssueService issueService = new IssueService();

        // Display all issues
        Console.WriteLine("\nDisplaying Issues:");
        issueService.DisplayAllIssues(issues);

        // Report status
        Console.WriteLine();
        Console.WriteLine("Reporting Status of Issues:");
        issueService.GetAllReportStatus(reportables);

        // Get summary
        Console.WriteLine();
        Console.WriteLine("Getting Summary of Issues:");
        issueService.GetAllSummary(reportables);

        int openCount = 0;
        int closedCount = 0;
        int inProgressCount = 0;

        foreach (var issue in issues.OfType<IReportable>())
        {
            if (issue.Status == "Open")
            {
                openCount++;
            }
            else if (issue.Status == "Closed")
            {
                closedCount++;
            }
            else if (issue.Status == "In Progress")
            {
                inProgressCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Total Open Issues Before Updating: {openCount}");
        Console.WriteLine($"Total In Progress Issues Before Updating: {inProgressCount}");
        Console.WriteLine($"Total Closed Issues Before Updating: {closedCount}");


        // Update status
        Console.WriteLine();
        Console.WriteLine("Updating Status of Issues:");
        
        bug.UpdateStatus("Closed");
        task.UpdateStatus("Closed");
        featureRequest.UpdateStatus("In Progress");

        openCount = 0;
        closedCount = 0;
        inProgressCount = 0;

        foreach (var issue in issues.OfType<IReportable>())
        {
            if (issue.Status == "Open")
            {
                openCount++;
            }
            else if (issue.Status == "Closed")
            {
                closedCount++;
            }
            else if (issue.Status == "In Progress")
            {
                inProgressCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Total Open Issues After Updating: {openCount}");
        Console.WriteLine($"Total In Progress Issues After Updating: {inProgressCount}");
        Console.WriteLine($"Total Closed Issues After Updating: {closedCount}");

    }
}

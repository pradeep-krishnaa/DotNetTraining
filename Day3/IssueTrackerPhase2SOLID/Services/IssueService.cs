using System;
using System.Collections.Generic;
using IssueTrackerPhase2SOLID.Models;

namespace IssueTrackerPhase2SOLID.Services;

public class IssueService : IIssueService
{
    public void DisplayAllIssues(List<Issue> issues)
    {
        foreach (var issue in issues)
        {
            issue.Display();
        }
    }
    public void GetAllSummary(List<IReportable> issuesum)
    {
        foreach (var issue in issuesum)
        {
            issue.GetSummary();
        }
    }
    public void GetAllReportStatus(List<IReportable> reportables)
    {
        foreach (var reportable in reportables)
        {
            reportable.ReportStatus();
        }
    }
}


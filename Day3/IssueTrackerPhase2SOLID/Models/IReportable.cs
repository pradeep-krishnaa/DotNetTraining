using System;

namespace IssueTrackerPhase2SOLID.Models
{
    public interface IReportable
    {
        string Status { get; set; }
        void ReportStatus();
        void GetSummary();
        void UpdateStatus(string newStatus);
    }
}
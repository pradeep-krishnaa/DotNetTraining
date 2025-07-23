using System;

namespace Day2Proj1Phase2.Models
{
    public interface IReportable
    {
        string Status { get; set; }
        void ReportStatus();
        void GetSummary();
        void UpdateStatus(string newStatus);
    }
}
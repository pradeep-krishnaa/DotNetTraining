using System;

namespace Day2Proj2.Models
{
    public class FeatureRequest : SupportTicket, IReportable
    {
        public string RequestedBy { get; set; }
        public string ETA { get; set; } // Estimated Time of Arrival for the feature;

        public FeatureRequest(int id, string title, string description, string createdBy, string status, string requestedBy, string eta)
            : base(id, title, description, createdBy, status)
        {
            RequestedBy = requestedBy;
            ETA = eta;
        }

        public override void Display()
        {
            Console.WriteLine($"Feature Request #Id: {Id} , Title: {Title} , Desc: {Description} , CreatedBy: {CreatedBy} , RequestedBy: {RequestedBy} , ETA: {ETA}");
        }
        public void ReportStatus()
        {
            Console.WriteLine($"Feature Request Status: {Status}");
        }
    }
}
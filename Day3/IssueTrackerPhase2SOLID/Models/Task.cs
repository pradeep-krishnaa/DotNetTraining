
using System;

namespace IssueTrackerPhase2SOLID.Models
{
    public class Task : Issue, IReportable
    {
        public int EstimatedHours { get; set; }
        public string Status { get; set; } = "In Progress"; // Implementing the Status property from IReportable interface
        public Task(int id, string title, string assignedTo, int estimatedHours)
        : base(id, title, assignedTo)
        {
            if (!IsValid)
            {
                return;
            }

            if (estimatedHours <= 0)
            {
                Console.WriteLine("Invalid Task: EstimatedHours must be greater than 0.");
                IsValid = false;
            }
            else
            {
                EstimatedHours = estimatedHours;
                IsValid = true;
            }
        }

        public override void Display()
        {
            Console.Write("[Task] ");
            Console.WriteLine($"Estimated Hours: {EstimatedHours}");
        }
        public void ReportStatus()
        {
            Console.WriteLine($"Task #{ID} is in progress. Status - {Status}");
        }

        public void GetSummary()
        {
            Console.WriteLine($"Task Summary: ID = {ID}, Title = {Title}, Assigned To = {AssignedTo}, Estimated Hours = {EstimatedHours} , Status - {Status}");
        }
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Task #{ID} status updated to: {Status}");
        }
    }
}
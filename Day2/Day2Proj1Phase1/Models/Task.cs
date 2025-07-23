using System;

namespace Day2Proj1Phase1.Models
{
    public class Task : Issue , IReportable
    {
        public int EstimatedHours { get; set; }
        public Task(int id, string title, string assignedTo, int estimatedhours) : base(id, title, assignedTo)
        {
            EstimatedHours = estimatedhours;
        }
        public override void Display()
        {
            Console.Write("[Task] ");
            base.Display();
            Console.WriteLine($"Estimated Hours: {EstimatedHours}");
        }
        public void ReportStatus()
        {
            Console.WriteLine($"Task #{ID} is in progress. Estimated Hours - {EstimatedHours}");
        }
    }
}
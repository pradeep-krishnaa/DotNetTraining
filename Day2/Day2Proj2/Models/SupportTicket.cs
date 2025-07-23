using System;

namespace Day2Proj2.Models;

public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; } // User who created the ticket
    public string Status { get; set; } = "Open";// e.g., "Open", "In Progress", "Closed"

    public SupportTicket(int id, string title, string description, string createdBy, string status)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedBy = createdBy;
        Status = status;
    }

    public virtual void Display()
    {
        Console.WriteLine($"#Id: {Id} , Title: {Title} , Desc: {Description} , CreatedBy: {CreatedBy} , Status: {Status}");
    }

    public void CloseTicket()
    {
        Status = "Closed";
        Console.WriteLine($"Ticket #{Id} status updated to: Closed");
    }

}
using System;

namespace Day1Proj1Phase2.Models
{
    public class Ticket
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; private set; }
        public User CreatedBy { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;




        // Constructor
        public Ticket(int id, string title, string desc, User createdBy, string priority)
        {
            Id = id;
            Title = title;
            Description = desc;
            CreatedBy = createdBy;
            Status = "Open"; // Default status when a ticket is created
            Priority = priority;
        }

        public void CloseTicket()
        {
            Status = "Closed"; // Change status to Closed
        }

        public void DisplayTicket()
        {
            Console.WriteLine($"Ticket ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Created By: {CreatedBy.Name} (Role: {CreatedBy.Role})");
        }

        public void ReassignTicket(User newUser)
        {
            CreatedBy = newUser; // Reassign the ticket to a new user
            Console.WriteLine($"Ticket {Id} has been reassigned to {newUser.Name}.");
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"Ticket #{Id}:{Title} - {Status} - {Priority} - Assigned To:{CreatedBy.Name} Created on:{CreatedAt}");
        }
    }
}

using System;

namespace Day1Proj1Phase1.Models
{

    public class Ticket
    {
	    

            public int Id { get; private set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Status { get; private set; }

            public User CreatedBy { get; set; }
            public Ticket(int id, string title, string desc, User createdBy)
            {
                Id = id;
                Title = title;
                Description = desc;
                CreatedBy = createdBy;
                Status = "Open"; // Default status when a ticket is created

            }

            public void CloseTicket()
            {
                Status = "Closed"; // Change status to Closed
            }

            public void DisplayTicket()
            {
                Console.WriteLine($"Ticket ID: {Id}");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Description : {Description}");
                Console.WriteLine($"Status: {Status}");
                Console.WriteLine($"Created By: {CreatedBy.Name} (Role: {CreatedBy.Role})");
            }
        
    }
}


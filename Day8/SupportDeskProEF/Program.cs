using Microsoft.EntityFrameworkCore;
using SupportDeskEF.Data;
//using SupportDeskProEF.Data;
using SupportDeskProEF.Models;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        // Clear old data (optional for dev/testing)
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Create Department
        var department = new Department { Name = "Technical Support" };
        context.Departments.Add(department);

        // Create Users
        var user1 = new User { Name = "Alice", Email = "alice@example.com", UserType = "Customer" };
        var user2 = new User { Name = "Bob", Email = "bob@example.com", UserType = "SupportAgent" };
        context.Users.AddRange(user1, user2);
        context.SaveChanges();

        // Add CustomerProfile for user1
        var profile = new CustomerProfile { UserId = user1.UserId, Address = "123 Street", Phone = "9998887776" };
        context.CustomerProfiles.Add(profile);

        // Make user2 a support agent
        var agent = new SupportAgent { UserId = user2.UserId, DepartmentId = department.DepartmentId };
        context.SupportAgents.Add(agent);

        // Create Category
        var category = new Category { Name = "Login Issues" };
        context.Categories.Add(category);
        context.SaveChanges();

        // Create Ticket for user1
        var ticket = new Ticket
        {
            Title = "Cannot log in",
            Description = "Forgot password and can't reset",
            CreatedDate = DateTime.Now,
            Status = "Open",
            CustomerId = user1.UserId,
            CategoryId = category.CategoryId
        };
        context.Tickets.Add(ticket);
        context.SaveChanges();

        // Assign ticket to support agent
        var tsa = new TicketSupportAgent
        {
            TicketId = ticket.TicketId,
            SupportAgentId = agent.SupportAgentId
        };
        context.TicketSupportAgents.Add(tsa);
        context.SaveChanges();

        // Add Ticket History
        var history = new TicketHistory
        {
            TicketId = ticket.TicketId,
            Action = "Ticket created by customer",
            Timestamp = DateTime.Now
        };
        context.TicketHistories.Add(history);
        context.SaveChanges();

        // Display Data
        Console.WriteLine("Tickets and Assignments:");
        var tickets = context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.Category)
            .Include(t => t.TicketSupportAgents)
                .ThenInclude(tsa => tsa.SupportAgent)
                    .ThenInclude(sa => sa.User)
            .ToList();


        foreach (var t in tickets)
        {
            Console.WriteLine($"Title: {t.Title}");
            Console.WriteLine($"Customer: {t.Customer.Name}");
            Console.WriteLine($"Category: {t.Category.Name}");
            Console.WriteLine("Assigned Agents:");
            foreach (var tttt in t.TicketSupportAgents)
            {
                Console.WriteLine($"- {tttt.SupportAgent.User.Name}");
            }
            Console.WriteLine("-----------------------------");
        }

    }
}

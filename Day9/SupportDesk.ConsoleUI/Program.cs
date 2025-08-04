using System;
using System.Threading.Tasks;
using SupportDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using System.Linq;
using SupportDesk.Application.Services;

namespace SupportDesk.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDBContext();
            User pradeep = new User { UserName = "Pradeep" };
            Ticket ticket1 = new Ticket { Title = "Issue with product", User = pradeep };
            Ticket ticket2 = new Ticket { Title = "Another issue with product", User = pradeep };
            Tag bug = new Tag { Name = "Bug" };
            Tag UI = new Tag { Name = "UI" };
            TicketTag ticketTag1 = new TicketTag { Ticket = ticket1, Tag = bug };
            TicketTag ticketTag2 = new TicketTag { Ticket = ticket1, Tag = UI };

            context.Users.Add(pradeep);
            context.Tickets.Add(ticket1);
            context.Tickets.Add(ticket2);
            context.Tags.Add(bug);
            context.Tags.Add(UI);
            context.TicketTags.Add(ticketTag1);
            context.TicketTags.Add(ticketTag2);
            context.SaveChanges();

            TicketService ticketService = new TicketService(context);
            var tickets = ticketService.GetAllTickets();
            Console.WriteLine("All Tickets:");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Ticket ID: {ticket.TicketId}, Title: {ticket.Title}");
            }
            Console.WriteLine("Tickets with Users:");
            var ticketsWithUsers = ticketService.GetTicketsWithUsers();
            foreach (var ticket in ticketsWithUsers)
            {
                Console.WriteLine($"Ticket ID: {ticket.TicketId}, Title: {ticket.Title}, User: {ticket.User.UserName}");
            }
            Console.WriteLine("Tickets with Tags:");
            var ticketsWithTags = ticketService.GetTicketsWithTags();
            foreach (var ticket in ticketsWithTags)
            {
                Console.WriteLine($"Ticket ID: {ticket.TicketId}, Title: {ticket.Title}, Tags: {string.Join(", ", ticket.TicketTags.Select(tt => tt.Tag.Name))}");
            }
            Console.WriteLine("Users with Tickets:");
            var usersWithTickets = ticketService.GetUsersWithTickets();

            foreach (var user in usersWithTickets)
            {
                Console.Write($"User: {user.UserName}, Tickets: ");
                foreach (var ticket in user.Tickets)
                {
                    Console.Write($"{ticket.Title} ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("Tag Ticket Count:");
            var tagTicketCount = ticketService.GetTagTicketCount();
            foreach (var tagCount in tagTicketCount)
            {
                Console.WriteLine($"Tag: {tagCount.TagName}, Ticket Count: {tagCount.TicketCount}");
            }
            Console.WriteLine("Ticket Counts by Users:");
            var ticketCountsByUsers = ticketService.GetTicketCountsByUsers();
            foreach (var userCount in ticketCountsByUsers)
            {
                Console.WriteLine($"User: {userCount.TagName}, Ticket Count: {userCount.TicketCount}");
            }
            Console.WriteLine("Tickets by User ID:");
            var ticketsByUserId = ticketService.GetTicketsByUserId(pradeep.UserId);
            foreach (var ticket in ticketsByUserId)
            {
                Console.WriteLine($"Ticket ID: {ticket.TicketId}, Title: {ticket.Title}, User: {ticket.User.UserName}");
            }
            Console.WriteLine("Tickets by Tag ID:");
            var ticketsByTagId = ticketService.GetTicketsByTagId(bug.TagId);
            foreach (var ticket in ticketsByTagId)
            {
                Console.WriteLine($"Ticket ID: {ticket.TicketId}, Title: {ticket.Title}, Tags: {string.Join(", ", ticket.TicketTags.Select(tt => tt.Tag.Name))}");
            }
            Console.WriteLine("Tickets with Users and Tags:");
            var ticketsWithUsersAndTags = ticketService.GetTicketsWithUsersAndTags();
            foreach (var ticket in ticketsWithUsersAndTags)
            {
                Console.WriteLine(ticket); // this will call ToString() of the anonymous type
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();




        }
    }
}
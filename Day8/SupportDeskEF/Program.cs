using Microsoft.EntityFrameworkCore;
using SupportDeskEF.Data;
using SupportDeskEF.Models;
using System;
using System.Linq;

namespace SupportDeskEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();



            User alice = new User { UserName = "Alice" };
            Ticket ticket = new Ticket {  Title = "Login Issue" , User = alice };
            Tag bug = new Tag { Name = "Bug" };
            Tag UI = new Tag { Name = "UI" };

            TicketTag ticketTag1 = new TicketTag { Ticket = ticket, Tag = bug }; //TicketTag mappings to link Ticket and Tag
            TicketTag ticketTag2 = new TicketTag { Ticket = ticket, Tag = UI };

            //add all objects to the context

            context.Users.Add(alice);
            context.Tickets.Add(ticket);
            context.Tags.Add(bug);
            context.Tags.Add(UI);
            context.TicketTags.Add(ticketTag1); //Adding TicketTag mappings to the context
            context.TicketTags.Add(ticketTag2);
            context.SaveChanges();

            var Tickets = context.Tickets
                .Include(t => t.User)
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();

            foreach (var t in Tickets)
            {
                Console.WriteLine($"Ticket: {t.Title}, User: {t.User.UserName}");
                foreach (var tt in t.TicketTags)
                {
                    Console.WriteLine($" - Tag: {tt.Tag.Name}");
                }
            }








        }
    }
}
using System;
using BugTrackerLite.Models;
using Microsoft.EntityFrameworkCore;
using BugTrackerLite.Data;
using System.Linq;
using System.Collections.Generic;
using BugTrackerLite.Services;

namespace BUgTrackerLite;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new AppDBContext();
        IssueService issueService = new IssueService(context);
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("====== Bug Tracker Menu ====== ");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Create Tcket and assign to a User");
            Console.WriteLine("3. Create Tag");
            Console.WriteLine("4. Assign Tag to Ticket");
            Console.WriteLine("5. Mark Tickets as Resolved");
            Console.WriteLine("6. View Tickets with users and tags");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Select an option:");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":

                    CreateUser(issueService, context);
                    break;
                    
                case "2":
                    CreateTicket(issueService, context);
                    break;
                case "3":
                    CreateTag(issueService, context);
                    break;
                case "4":
                    if(issueService.TicketCount == 0)
                    {
                        Console.WriteLine("No tickets created . Please create a ticket first.");
                        break;
                    }
                    if(issueService.TagCount == 0)
                    {
                        Console.WriteLine("No tags created . Please create a tag first.");
                        break;
                    }
                    Console.WriteLine("Enter Ticket id:");
                    var ticketIdToAssignTag = int.Parse(Console.ReadLine());
                    while (issueService.GetTicketById(ticketIdToAssignTag) == null)
                    {
                        
                        Console.WriteLine("Ticket not found. Please enter a valid Ticket id.");
                        ticketIdToAssignTag = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Enter Tag id:");
                    var tagIdToAssign = int.Parse(Console.ReadLine());
                    while (issueService.GetTagById(tagIdToAssign) == null)
                    {
                        
                        Console.WriteLine("Tag not found. Please enter a valid Tag id.");
                        tagIdToAssign = int.Parse(Console.ReadLine());
                    }
                    var ticketTag = new TicketTag { Ticket=issueService.GetTicketById(ticketIdToAssignTag), Tag=issueService.GetTagById(tagIdToAssign) };
                    context.TicketTags.Add(ticketTag);
                    context.SaveChanges();
                    Console.WriteLine("Tag assigned to ticket successfully.");
                    break;
                case "5":
                    if(issueService.TicketCount == 0)
                    {
                        Console.WriteLine("No tickets created . Please create a ticket first.");
                        break;
                    }
                    Console.WriteLine("Enter Ticket id to mark as resolved:");
                    var ticketIdToResolve = int.Parse(Console.ReadLine());
                    //var ticketToUpdate = context.Tickets.FirstOrDefault(t => t.TicketId == ticketIdToResolve);
                    Ticket ticketToUpdate = issueService.GetTicketById(ticketIdToResolve);
                    while (ticketToUpdate == null)
                    {
                        Console.WriteLine("Ticket not found. Please enter a valid Ticket id.");
                        ticketIdToResolve = int.Parse(Console.ReadLine());
                        ticketToUpdate = context.Tickets.FirstOrDefault(t => t.TicketId == ticketIdToResolve);
                    }
                    
                    ticketToUpdate.Status = "Resolved";
                    Console.WriteLine("Ticket Resolved");
                    break;
                case "6":
                    if(issueService.TicketCount == 0)
                    {
                        Console.WriteLine("No tickets created . Please create a ticket first.");
                        break;
                    }
                    Console.WriteLine("Tickets with Users and Tags:");
                    var ticketsWithDetails = issueService.GetAllTicketsWithUsersandTags();
                    foreach (var t in ticketsWithDetails)
                    {
                        Console.WriteLine($"Ticket ID: {t.TicketId}, Title: {t.Title}, Status: {t.Status}, User: {t.User.UserName}");
                        if (issueService.TicketTagCount == 0)
                            Console.WriteLine("No tags assigned to this ticket.");
                        
                        else { 
                            foreach (var tt in t.TicketTags)
                            {
                                Console.WriteLine($"Tag: {tt.Tag.TagName}");
                            }
                        }
                    }
                    break;
                case "7":
                    exit = false;
                    Console.WriteLine("Exiting the application.");
                    break;
            }

        }
    }
    public static void CreateUser(IssueService issueService, AppDBContext context)
    {
        Console.WriteLine("Enter User id:");
        var userId = int.Parse(Console.ReadLine());
        while (issueService.GetUserById(userId) != null)
        {
            Console.WriteLine("User id already exists. Please enter a different User id:");
            userId = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter User Name:");
        var userName = Console.ReadLine();
        var user = new User { UserId = userId, UserName = userName };
        context.Users.Add(user);
        context.SaveChanges();
        Console.WriteLine("User created successfully.");
    }

    public static void CreateTicket(IssueService issueService, AppDBContext context)
    {
        if(issueService.UserCount == 0)
        {
            Console.WriteLine("No users created . Please create a user first.");
            return;
        }
        Console.WriteLine("Enter Ticket id:");
        var ticketId = int.Parse(Console.ReadLine());
        while (issueService.GetTicketById(ticketId) != null)
        {
            Console.WriteLine("Ticket id already exists. Please enter a different Ticket id:");
            ticketId = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter Ticket Title:");
        var title = Console.ReadLine();
        Console.WriteLine("Enter Ticket Description:");
        var description = Console.ReadLine();
        Console.WriteLine("Enter User id to assign this ticket:");
        var userId = int.Parse(Console.ReadLine());
        while (issueService.GetUserById(userId) == null)
        {
            Console.WriteLine("User not found. Please enter a valid User id.");
            userId = int.Parse(Console.ReadLine());
        }
        
        var ticket = new Ticket { TicketId = ticketId, Title = title, Description = description, UserId = userId };
        context.Tickets.Add(ticket);
        context.SaveChanges();
        Console.WriteLine("Ticket created successfully.");

    }
    public static void CreateTag(IssueService issueService, AppDBContext context)
    {
        Console.WriteLine("Enter Tag id:");
        var tagId = int.Parse(Console.ReadLine());
        while (issueService.GetTagById(tagId) != null)
        {
            Console.WriteLine("Tag id already exists. Please enter a different Tag id:");
            tagId = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter Tag Name:");
        var tagName = Console.ReadLine();
        var tag = new Tag { TagId = tagId, TagName = tagName };
        context.Tags.Add(tag);
        context.SaveChanges();
        Console.WriteLine("Tag created successfully.");
    }
}
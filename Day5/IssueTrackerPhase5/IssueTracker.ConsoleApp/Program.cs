using IssueTracker.Application.Services;
using IssueTracker.Core.Interfaces;
using IssueTracker.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main(string[] args)
    {
        // Initialize the repository and service
        IBugRepository bugRepository = new BugRepository();
        IBugService bugService = new BugService(bugRepository);
        

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Issue Tracker Console Application");
            Console.WriteLine("1. Create Bug");
            Console.WriteLine("2. View All Bugs");
            Console.WriteLine("3. View Bug by ID");
            Console.WriteLine("4. Update Bug");
            Console.WriteLine("5. Delete Bug");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateBug(bugService);
                    break;
                case "2":
                    ViewAllBugs(bugService);
                    break;
                case "3":
                    ViewBugById(bugService);
                    break;
                case "4":
                    UpdateBug(bugService);
                    break;
                case "5":
                    DeleteBug(bugService);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
    private static void CreateBug(IBugService bugService)
    {
        Console.Write("Enter Bug Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Bug Description: ");
        string description = Console.ReadLine();
        
        try
        {
            bugService.CreateBug(title, description);
            Console.WriteLine("Bug created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating bug: {ex.Message}");
        }
    }

    private static void ViewAllBugs(IBugService bugService)
    {
        var bugs = bugService.GetAllBugs();
        if (bugs.Count == 0)
        {
            Console.WriteLine("No bugs found.");
            return;
        }
        
        Console.WriteLine("List of Bugs:");
        foreach (var bug in bugs)
        {
            Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Status: {bug.Status}");
        }
    }

    private static void ViewBugById(IBugService bugService)
    {
        Console.Write("Enter Bug ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            try
            {
                var bug = bugService.GetBugById(id);
                Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Description: {bug.Description}, Status: {bug.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving bug: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static void UpdateBug(IBugService bugService)
    {
        Console.Write("Enter Bug ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Enter new Title: ");
            string newTitle = Console.ReadLine();
            Console.Write("Enter new Status: ");
            string newStatus = Console.ReadLine();
            
            try
            {
                bugService.UpdateBug(id, newTitle, newStatus);
                Console.WriteLine("Bug updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating bug: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static void DeleteBug(IBugService bugService)
    {
        Console.Write("Enter Bug ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            try
            {
                bugService.DeleteBug(id);
                Console.WriteLine("Bug deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting bug: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }   


}
using System;
using System.ComponentModel.DataAnnotations;
using BugStatsDashboard.Application.Services;
using BugStatsDashboard.Core.Interfaces;
using BugStatsDashboard.Infrastructure.DTOs;
using BugStatsDashboard.Infrastructure.Repositories;

public class Program
{
    private static IBugService _bugService;
    public static void Main(string[] args)
    {
        IBugRepository bugRepository = new BugRepository();
        BugService bugService = new BugService(bugRepository);
        Console.WriteLine("Bug Stats Dashboard");
        Console.WriteLine("-------------------");
        Console.WriteLine("1. View All Bugs");
        Console.WriteLine("2. View Bugs by Project");
        Console.WriteLine("3. View Bugs by Status");
        Console.WriteLine("4. View Bugs by Priority");
        Console.WriteLine("5. Show Count by Created Date");
        Console.WriteLine("6. Show Count by Priority");
        Console.WriteLine("7. Show Count by User");
        Console.WriteLine("8. Exit");
        while (true)
        {
            Console.Write("\nSelect an option: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayBugs(bugService.ViewAllBugs(), "All Bugs");
                    break;
                case "2":
                    DisplayBugs(bugService.ViewBugsByProject(), "Bugs by Project");
                    break;
                case "3":
                    DisplayBugs(bugService.ViewBugsByStatus(), "Bugs by Status");
                    break;
                case "4":
                    DisplayBugs(bugService.ViewBugsByPriority(), "Bugs by Priority");
                    break;
                case "5":
                    DisplayGroups(bugService.ShowCountByCreatedDate(), "Bugs by Created Date");
                    break;
                case "6":
                    DisplayGroups(bugService.ShowCountByPriority(), "Bugs by Priority");
                    break;
                case "7":
                    DisplayGroups(bugService.ShowCountByUser(), "Bugs by User");
                    break;
                case "8":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;


            }
        }
    }
    private static void DisplayBugs(List<BugDTO> bugs, string title)
    {
        Console.WriteLine($"\n{title}:");
        if (bugs.Count == 0)
        {
            Console.WriteLine("No bugs found.");
            return;
        }

        foreach (var bug in bugs)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title         : {bug.Title}");
            Console.WriteLine($"Project       : {bug.ProjectName}");
            Console.WriteLine($"Assigned User : {bug.AssignedUserName}");
            Console.WriteLine($"Status        : {bug.Status}");
            Console.WriteLine($"Priority      : {bug.Priority}");
        }
        Console.WriteLine("--------------------------------------------------");
    }


    private static void DisplayGroups(List<GroupStatsDTO> groups, string title)
    {
        Console.WriteLine($"\n{title}:");
        if (groups.Count == 0)
        {
            Console.WriteLine("No data found.");
            return;
        }
        foreach (var group in groups)
        {
            Console.WriteLine($"Key: {group.Key}, Value1: {group.Count}");
        }
    }


}
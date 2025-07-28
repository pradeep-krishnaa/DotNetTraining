using IssueTracker.Application.Services;
using IssueTracker.Core.Entities;
using IssueTracker.Infrastructure.Repositories;
using IssueTracker.Core.Interfaces;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        var bugRepository = new BugRepository();
        var bugService = new BugService(bugRepository);

        // Creating  a new bug
        bugService.CreateBug("Login Bug", "Login Issue.");
        bugService.CreateBug("UI Bug", "UI Issue.");


        var bugs = bugService.GetAllBugs();
        foreach (var bug in bugs)
        {
            Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Description: {bug.Description}, Status: {bug.Status}");
        }
        Console.ReadLine();
    }
}
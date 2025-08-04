using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugStatsDashboard.Core.Entities;
using BugStatsDashboard.Core.Interfaces;
using BugStatsDashboard.Application.Services;
using BugStatsDashboard.Infrastructure.Repositories;

public class Program
{
    public static void Main(string[] args)

    {

        IBugRepository bugRepository = new BugRepository();
        BugStatsService bugStatsService = new BugStatsService(bugRepository);

        Console.WriteLine("Bug Statistics Dashboard");
        Console.WriteLine("1. Show Bug Count by Status");
        Console.WriteLine("2. Show Bug Count by Project and Priority");
        Console.WriteLine("3. Show Daily Bug Report");
        Console.WriteLine("4. Show Top Creators");
        Console.WriteLine("5. Exit");
        bool exit = true;
        while (exit)
        {
            Console.Write("Select an option (1-5): ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bugStatsService.ShowBugCountByStatus();
                    break;
                case "2":
                    bugStatsService.ShowBugCountByProjectAndPriority();
                    break;
                case "3":
                    bugStatsService.ShowDailyBugReport();
                    break;
                case "4":
                    bugStatsService.ShowTopCreators();
                    break;
                case "5":
                    exit = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
        Console.WriteLine("Exiting Bug Statistics Dashboard. Goodbye!");
        Console.ReadKey();


    }
}
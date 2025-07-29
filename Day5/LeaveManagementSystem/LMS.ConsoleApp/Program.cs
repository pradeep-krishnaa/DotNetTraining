using LMS.Application.Services;
using LMS.Core.Interfaces;
using LMS.Infrastructure.Repositories;
using LMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        ILeaveRepository leaveRepository = new LeaveRepository();
        ILeaveService leaveService = new LeaveService(leaveRepository);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Leave Management System");
            Console.WriteLine("1. Create Leave");
            Console.WriteLine("2. View All Leaves");
            Console.WriteLine("3. View Leave by ID");
            Console.WriteLine("4. Update Leave");
            Console.WriteLine("5. Delete Leave");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateLeave(leaveService);
                    break;
                case "2":
                    ViewAllLeaves(leaveService);
                    break;
                case "3":
                    ViewLeaveById(leaveService);
                    break;
                case "4":
                    UpdateLeave(leaveService);
                    break;
                case "5":
                    DeleteLeave(leaveService);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

    }

    public static void CreateLeave(ILeaveService leaveService)
    {
        Console.Write("Enter Employee Name: ");
        string employeeName = Console.ReadLine();
        Console.Write("Enter Start Date : ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter End Date : ");
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Reason(sick/casual): ");
        string reason = Console.ReadLine();
        leaveService.CreateLeave(employeeName, startDate, endDate, reason);
        Console.WriteLine("Leave created successfully.");
    }
    public static void ViewAllLeaves(ILeaveService leaveService)
    {
        var leaves = leaveService.GetAllLeaves();
        if (leaves.Count == 0)
        {
            Console.WriteLine("No Leave Data found.");
        }
        else
        {
            foreach (var leave in leaves)
            {
                Console.WriteLine($"ID: {leave.Id}, Employee: {leave.EmployeeName}, Start Date: {leave.StartDate.ToShortDateString()}, End Date: {leave.EndDate.ToShortDateString()}, Reason: {leave.Reason}");
            }
        }
    }
    public static void ViewLeaveById(ILeaveService leaveService)
    {
        Console.Write("Enter Leave ID: ");
        int id = int.Parse(Console.ReadLine());
        var leave = leaveService.GetLeaveById(id);
        if (leave == null)
        {
            Console.WriteLine("Leave not found.");
        }
        else
        {
            Console.WriteLine($"ID: {leave.Id}, Employee: {leave.EmployeeName}, Start Date: {leave.StartDate.ToShortDateString()}, End Date: {leave.EndDate.ToShortDateString()}, Reason: {leave.Reason}");
        }
    }
    public static void UpdateLeave(ILeaveService leaveService)
    {
        Console.Write("Enter Leave ID to update: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter New Employee Name: ");
        string newEmployeeName = Console.ReadLine();
        Console.Write("Enter New Start Date: ");
        DateTime newStartDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter New End Date: ");
        DateTime newEndDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter New Reason: ");
        string newReason = Console.ReadLine();
        leaveService.UpdateLeave(id, newEmployeeName, newStartDate, newEndDate, newReason);
        Console.WriteLine("Leave updated successfully.");
    }
    public static void DeleteLeave(ILeaveService leaveService)
    {
        Console.Write("Enter Leave ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        leaveService.DeleteLeave(id);
        Console.WriteLine("Leave deleted successfully.");
    }

}


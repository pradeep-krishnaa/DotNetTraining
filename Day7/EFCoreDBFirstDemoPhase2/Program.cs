using System;
using System.Linq;
using EFCoreDBFirstDemoPhase2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBFirstDemoPhase2
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CompanyContext();
            //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Employee', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Departments', RESEED, 0)");

            context.Departments.Add(new Department { DeptName = "IT" });
            context.SaveChanges();
            context.Departments.AddRange(
                new Department { DeptName = "HR" },
                new Department { DeptName = "Finance" }
            );

            context.SaveChanges();

            context.Employees.AddRange(
                new Employee { EmpId = 101, EmpName = "Pradeep", EmpAge = 20, DeptId = 1 },
                new Employee { EmpId = 102, EmpName = "Krishnaa", EmpAge = 21, DeptId = 2 },
                new Employee { EmpId = 103, EmpName = "Jeff", EmpAge = 19, DeptId = 3 }
            );

            context.SaveChanges();

            Console.WriteLine("------ All Employees with Department Info ------");

            var employees = context.Employees
                .Include(e => e.Dept) // Eagerly load the Department navigation property
                .ToList();

            foreach (var emp in employees)
            {
                string deptName = emp.Dept != null ? emp.Dept.DeptName : "N/A";
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpAge: {emp.EmpAge}, Department: {deptName}");
            }
            Console.WriteLine($"Total Employees found: {employees.Count}");
            Console.WriteLine();

            Console.WriteLine("------ Updating Employee Id 101 ------");
            int empIdToUpdate = 101;

            var employee = context.Employees.Find(empIdToUpdate); // efficient primary key lookup
            // Alternatively, you can use FirstOrDefault if you want to search by other criteria
            // var employee = context.Employees.FirstOrDefault(e => e.EmpId == empIdToUpdate);

            if (employee != null)
            {
                employee.EmpName = "Adhnan";
                employee.EmpAge = 23;
                employee.DeptId = 2; // optional

                context.SaveChanges();
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
            Console.WriteLine();

            Console.WriteLine("------ All Employees after Update ------");
            var updatedEmployees = context.Employees
                .Include(e => e.Dept) // Eagerly load the Department navigation property
                .ToList();
            foreach (var emp in updatedEmployees)
            {
                string deptName = emp.Dept != null ? emp.Dept.DeptName : "N/A";
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpAge: {emp.EmpAge}, Department: {deptName}");
            }
            Console.WriteLine($"Total Employees found: {employees.Count}");
            Console.WriteLine();
            Console.WriteLine("------ Deleting Employee Id 101 ------");
            int empIdToDelete = 101;

            var employee2 = context.Employees.Find(empIdToDelete);

            if (employee2 != null)
            {
                context.Employees.Remove(employee2);
                context.SaveChanges();
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            Console.WriteLine();
            Console.WriteLine("------ All Employees after Deletion ------");
            var remainingEmployees = context.Employees
                .Include(e => e.Dept) // Eagerly load the Department navigation property
                .ToList();
            foreach (var emp in remainingEmployees)
            {
                string deptName = emp.Dept != null ? emp.Dept.DeptName : "N/A";
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpAge: {emp.EmpAge}, Department: {deptName}");
            }

            Console.WriteLine();
            Console.WriteLine("------ Deleting All Employees ------");
            var allEmployees = context.Employees.ToList();

            if (allEmployees.Any())
            {
                context.Employees.RemoveRange(allEmployees);
                context.SaveChanges();
                Console.WriteLine("All employees have been deleted.");
            }
            else
            {
                Console.WriteLine("No employees found to delete.");
            }
            Console.WriteLine();
            Console.WriteLine("------ Deleting All Depts ------");
            var alldepts = context.Departments.ToList();

            if (alldepts.Any())
            {
                context.Departments.RemoveRange(alldepts);
                context.SaveChanges();
                Console.WriteLine("All depts have been deleted.");
            }
            else
            {
                Console.WriteLine("No dept found to delete.");
            }
            //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Departments', RESEED, 0)");





        }
    }

}
using System;
using EFCoreDBFirstDemo.Models;
using System.Linq;

namespace EFCoreDBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new CompanyContext();
            Console.WriteLine("------ All Employees in the Company ------");
            var employees = context.Employees
                .Select(e => new
                {
                    e.EmpId,
                    e.EmpName,
                    e.EmpAge,
                    Department = e.Dept != null? e.Dept.DeptName : "N/A"
                })
                .ToList();
            Console.WriteLine($"Total Employees found.{employees.Count} ");

            foreach (var emp in employees)
            {
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpAge: {emp.EmpAge}, Department: {emp.Department}");
            }


        }
    }
}
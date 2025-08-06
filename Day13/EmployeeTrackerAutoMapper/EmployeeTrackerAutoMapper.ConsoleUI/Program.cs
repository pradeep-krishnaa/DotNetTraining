using System;
using EmployeeTrackerAutoMapper.Application.Mapping;
using EmployeeTrackerAutoMapper.Application.Services;
using EmployeeTrackerAutoMapper.Core.DTOs;
using EmployeeTrackerAutoMapper.Core.Interfaces;
using EmployeeTrackerAutoMapper.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTrackerAutoMapper.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var employeeRepository = new EmployeeRepository();
            var departmentRepository = new DepartmentRepository();
            var employeeService = new EmployeeService(employeeRepository, mapper);
            var departmentService = new DepartmentService(departmentRepository, mapper);

            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Employee Tracker - Choose an option:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Add Department");
                Console.WriteLine("7. Display All Departments");
                Console.WriteLine("9. Update Department");
                Console.WriteLine("10. Delete Department");
                Console.WriteLine("0. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var employeeRequest = new EmployeeRequestDTO();
                        Console.WriteLine("Enter Employee Name:");
                        employeeRequest.EmployeeName = Console.ReadLine();
                        Console.WriteLine("Enter Designation:");
                        employeeRequest.Designation = Console.ReadLine();
                        Console.WriteLine("Enter Department ID:");
                        employeeRequest.DepartmentId = int.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Enter Salary:");
                        employeeRequest.Salary = decimal.Parse(Console.ReadLine() ?? "0");
                        employeeService.AddEmployee(employeeRequest);
                        Console.WriteLine("Employee added successfully.");
                        break;

                        break;
                    case "2":
                        var employeeResponseDTO = employeeService.GetAllEmployees();
                        Console.WriteLine("All Employees:");
                        foreach (var employee in employeeResponseDTO)
                        {
                            Console.WriteLine($"Name: {employee.EmployeeName}, Designation: {employee.Designation}, Department ID: {employee.DepartmentId}");
                        }
                        break;
                        
                    
                    case "4":
                        // Logic to update employee
                        Console.WriteLine("Enter Employee ID to update:");
                        int updateId = int.Parse(Console.ReadLine() ?? "0");
                        var employeeToUpdate = employeeService.GetEmployeeById(updateId);
                        Console.WriteLine("Updating Employee:");
                        Console.WriteLine("Enter New Employee Name (leave blank to keep current):");
                        string? newName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newName))
                        {
                            employeeToUpdate.EmployeeName = newName;
                        }
                        Console.WriteLine("Enter New Designation (leave blank to keep current):");
                        string? newDesignation = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newDesignation))
                        {
                            employeeToUpdate.Designation = newDesignation;
                        }
                        Console.WriteLine("Enter New Department ID (leave blank to keep current):");
                        string? newDepartmentId = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newDepartmentId) && int.TryParse(newDepartmentId, out int depId))
                        {
                            employeeToUpdate.DepartmentId = depId;
                        }
                        Console.WriteLine("Enter New Salary (leave blank to keep current):");
                        string? newSalary = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newSalary) && decimal.TryParse(newSalary, out decimal salary))
                        {
                            employeeToUpdate.Salary = salary;
                        }
                        employeeService.UpdateEmployee(employeeToUpdate);
                        break;
                    case "5":
                        // Logic to delete employee
                        Console.WriteLine("Enter Employee ID to delete:");
                        int deleteId = int.Parse(Console.ReadLine() ?? "0");
                        employeeService.DeleteEmployee(deleteId);
                        Console.WriteLine("Employee deleted successfully.");
                        Console.ReadLine();
                        break;
                    case "6":
                        // Logic to add department
                        var departmentRequest = new DepartmentRequestDTO();
                        Console.WriteLine("Enter Department Name:");
                        departmentRequest.DeptName = Console.ReadLine();
                        departmentService.AddDepartment(departmentRequest);
                        Console.WriteLine("Department added successfully.");
                        break;
                    case "7":
                        // Logic to display all departments
                        var departmentResponseDTO = departmentService.GetAllDepartments();
                        Console.WriteLine("All Departments:");
                        foreach (var department in departmentResponseDTO)
                        {
                            Console.WriteLine($"Name: {department.DeptName}");
                        }

                        break;
                    case "9":
                        // Logic to update department
                        Console.WriteLine("Enter Department ID to update:");
                        int updateDeptId = int.Parse(Console.ReadLine() ?? "0");
                        var departmentToUpdate = departmentService.GetDepartmentById(updateDeptId);
                        Console.WriteLine("Updating Department:");
                        Console.WriteLine("Enter New Department Name (leave blank to keep current):");
                        string? newDeptName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newDeptName))
                        {
                            departmentToUpdate.DeptName = newDeptName;
                        }
                        break;
                    case "10":
                        // Logic to delete department
                        Console.WriteLine("Enter Department ID to delete:");
                        int deleteDeptId = int.Parse(Console.ReadLine() ?? "0");
                        departmentService.DeleteDepartment(deleteDeptId);
                        Console.WriteLine("Department deleted successfully.");

                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

        }
    }
}
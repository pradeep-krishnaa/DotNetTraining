using System;
using EmployeeTrackerGenericRepo.Application.Services;
using EmployeeTrackerGenericRepo.Core.Entities;
using EmployeeTrackerGenericRepo.Core.Interfaces;
using EmployeeTrackerGenericRepo.Infrastructure.Repositories;

namespace EmployeeTrackerGenericRepo.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            IDepartmentRepository departmentRepository = new DepartmentRepository();
            EmployeeService employeeService = new EmployeeService(employeeRepository);
            DepartmentService departmentService = new DepartmentService(departmentRepository);

            Console.WriteLine("Welcome to Employee Tracker!");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. View Employees by Department id");
            Console.WriteLine("5. View All Employees");
            Console.WriteLine("6. Add Department");
            Console.WriteLine("7. Update Department");
            Console.WriteLine("8. Delete Department");
            Console.WriteLine("9. View All Departments");
            Console.WriteLine("10. Exit");

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Select an option (1-10):");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter Employee Id:");
                        int empId = int.Parse(Console.ReadLine());
                        if (employeeService.GetEmployeeById(empId) != null)
                        {
                            Console.WriteLine("Employee with this Id already exists. Please use a different Id.");
                            break;
                        }
                        Console.WriteLine("Enter Employee Name:");
                        string empName = Console.ReadLine();
                        Console.WriteLine("Enter employee Designation:");
                        string empDesignation = Console.ReadLine();
                        Console.WriteLine("Enter Department Id:");
                        int deptId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Employee Salary:");
                        decimal empSalary = decimal.Parse(Console.ReadLine());
                        employeeService.AddEmployee(new Employee
                        {
                            EmployeeId = empId,
                            EmployeeName = empName,
                            Designation = empDesignation,
                            DepartmentId = deptId,
                            Salary = empSalary
                        });
                        Console.WriteLine("Employee added successfully.");
                        break;
                    case "2":
                        Console.WriteLine("Enter Employee Id to update:");
                        int empIdToUpdate = int.Parse(Console.ReadLine());
                        Employee empToUpdate = employeeService.GetEmployeeById(empIdToUpdate);
                        if (empToUpdate != null)
                        {
                            Console.WriteLine("Enter new Employee Name:");
                            empToUpdate.EmployeeName = Console.ReadLine();
                            Console.WriteLine("Enter new Department Id:");
                            empToUpdate.DepartmentId = int.Parse(Console.ReadLine());
                            employeeService.UpdateEmployee(empToUpdate);
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter Employee Id to delete:");
                        int empIdToDelete = int.Parse(Console.ReadLine());
                        employeeService.DeleteEmployee(empIdToDelete);
                        Console.WriteLine("Employee deleted successfully.");
                        break;
                    case "4":
                        Console.WriteLine("Enter Department Id to view employees:");
                        int departmentId = int.Parse(Console.ReadLine());
                        var employeesByDept = employeeService.GetEmployeesByDepartmentId(departmentId);
                        if (employeesByDept.Count > 0)
                        {
                            Console.WriteLine($"Employees in Department {departmentId}:");
                            foreach (var emp in employeesByDept)
                            {
                                Console.WriteLine($"Id: {emp.EmployeeId}, Name: {emp.EmployeeName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees found in this department.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("All Employees:");
                        var allEmployees = employeeService.GetAllEmployees();
                        if (allEmployees.Count > 0)
                        {
                            foreach (var emp in allEmployees)
                            {
                                Console.WriteLine($"Id: {emp.EmployeeId}, Name: {emp.EmployeeName}, Department Id: {emp.DepartmentId}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees found.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Enter Department Name:");
                        string deptName = Console.ReadLine();
                        departmentService.AddDepartment(new Department { DeptName = deptName });
                        Console.WriteLine("Department added successfully.");
                        break;
                    case "7":
                        Console.WriteLine("Enter Department Id to update:");
                        int deptIdToUpdate = int.Parse(Console.ReadLine());
                        Department deptToUpdate = departmentService.GetDepartmentById(deptIdToUpdate);
                        if (deptToUpdate != null)
                        {
                            Console.WriteLine("Enter new Department Name:");
                            deptToUpdate.DeptName = Console.ReadLine();
                            departmentService.UpdateDepartment(deptToUpdate);
                            Console.WriteLine("Department updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Department not found.");
                        }
                        break;
                    case "8":
                        Console.WriteLine("Enter Department Id to delete:");
                        int deptIdToDelete = int.Parse(Console.ReadLine());
                        departmentService.DeleteDepartment(deptIdToDelete);
                        Console.WriteLine("Department deleted successfully.");
                        break;
                    case "9":
                        Console.WriteLine("All Departments:");
                        var allDepartments = departmentService.GetAllDepartments();
                        if (allDepartments.Count > 0)
                        {
                            foreach (var dept in allDepartments)
                            {
                                Console.WriteLine($"Id: {dept.DeptId}, Name: {dept.DeptName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No departments found.");
                        }
                        break;
                    case "10":
                        loop = false;
                        Console.WriteLine("Exiting the application.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-10).");
                        break;


                }
            }
        }
    }
}
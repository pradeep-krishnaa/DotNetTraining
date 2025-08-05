using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTrackerGenericRepo.Core.Entities;
using EmployeeTrackerGenericRepo.Core.Interfaces;
using EmployeeTrackerGenericRepo.Infrastructure.Repositories;

namespace EmployeeTrackerGenericRepo.Application.Services
{
    internal interface IEmployeeService
    {
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();

        List<Employee> GetEmployeesByDepartmentId(int departmentId);
    }
}

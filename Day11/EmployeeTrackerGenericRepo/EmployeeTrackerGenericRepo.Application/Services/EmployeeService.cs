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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void AddEmployee(Employee emp)
        {
            _employeeRepository.Add(emp);
        }
        public void UpdateEmployee(Employee emp)
        {
            _employeeRepository.Update(emp);
        }
        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetById(id);
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }
        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return _employeeRepository.GetAll().Where(e => e.DepartmentId == departmentId).ToList();
        }

    }
}

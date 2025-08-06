using EmployeeTrackerAutoMapper.Core.Entities;
using EmployeeTrackerAutoMapper.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees= new();

        public int _nextId = 1;

        public void Add(Employee entity)
        {
            entity.EmployeeId = _nextId++;
            _employees.Add(entity);
        }
        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == id);
        }
        public List<Employee> GetAll()
        {
            return _employees;
        }

        public void Update(Employee entity)
        {
            var existingEmployee = GetById(entity.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = entity.EmployeeName;
                existingEmployee.Designation = entity.Designation;
                existingEmployee.DepartmentId = entity.DepartmentId;
                existingEmployee.Salary = entity.Salary;
            }
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}

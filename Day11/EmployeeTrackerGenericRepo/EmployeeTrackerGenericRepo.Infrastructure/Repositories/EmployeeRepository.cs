using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTrackerGenericRepo.Core.Entities;
using EmployeeTrackerGenericRepo.Core.Interfaces;

namespace EmployeeTrackerGenericRepo.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }
        public void Add(Employee entity)
        {
            _employees.Add(entity);
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
        public Employee GetById(int id)
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
                existingEmployee.DepartmentId = entity.DepartmentId;
                // Update other properties as needed
            }
        }
    }
}

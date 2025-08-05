using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTrackerGenericRepo.Core.Interfaces;
using EmployeeTrackerGenericRepo.Core.Entities;

namespace EmployeeTrackerGenericRepo.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _departments;
        public DepartmentRepository()
        {
            _departments = new List<Department>();
        }
        public void Add(Department entity)
        {
            _departments.Add(entity);
        }
        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _departments.Remove(department);
            }
        }
        public Department GetById(int id)
        {
            return _departments.FirstOrDefault(d => d.DeptId == id);
        }
        public List<Department> GetAll()
        {
            return _departments;
        }
        public void Update(Department entity)
        {
            var existingDepartment = GetById(entity.DeptId);
            if (existingDepartment != null)
            {
                existingDepartment.DeptName = entity.DeptName;
                // Update other properties as needed
            }
        }
    }
}

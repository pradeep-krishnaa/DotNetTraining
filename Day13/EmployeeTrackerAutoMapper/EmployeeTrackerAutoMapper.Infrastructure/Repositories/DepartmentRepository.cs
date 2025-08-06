using EmployeeTrackerAutoMapper.Core.Entities;
using EmployeeTrackerAutoMapper.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeTrackerAutoMapper.Infrastructure.Repositories
{
    public  class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _departments = new();

        public int _nextId = 1;
        public void Add(Department entity)
        {
            entity.DeptId = _nextId++;
            _departments.Add(entity);
        }

        public Department? GetById(int id)
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
            }
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _departments.Remove(department);
            }
        }


    }
}

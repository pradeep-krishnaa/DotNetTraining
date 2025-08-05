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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void AddDepartment(Department department)
        {
            _departmentRepository.Add(department);
        }
        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
        }
        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
        }
        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }
        public List<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }
    }
}

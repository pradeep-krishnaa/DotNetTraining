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
    public interface IDepartmentService
    {
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
        Department GetDepartmentById(int id);
        List<Department> GetAllDepartments();
    }
}

using EmployeeTrackerAutoMapper.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Core.Interfaces
{
    public interface IDepartmentService
    {
        //display -> return dept response DTO
        //add , update  -> get as dept request DTO
        void AddDepartment(DepartmentRequestDTO departmentRequestDTO);
        DepartmentRequestDTO? GetDepartmentById(int id);    //Req is used since it is used to update a department
        List<DepartmentResponseDTO> GetAllDepartments();
        void UpdateDepartment(DepartmentRequestDTO departmentRequestDTO);
        void DeleteDepartment(int id);
    }
}

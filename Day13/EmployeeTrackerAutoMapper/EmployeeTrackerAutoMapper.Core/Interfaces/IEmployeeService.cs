using EmployeeTrackerAutoMapper.Core.DTOs;
using EmployeeTrackerAutoMapper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Core.Interfaces
{
    public interface IEmployeeService   
    {
        //display -> return employee response DTO
        //add , update  -> get as employee request DTO
        void AddEmployee(EmployeeRequestDTO employeeRequestDTO);
        EmployeeRequestDTO? GetEmployeeById(int id);
        List<EmployeeResponseDTO> GetAllEmployees();
        void UpdateEmployee(EmployeeRequestDTO employeeRequestDTO);
        void DeleteEmployee(int id);
    }
}

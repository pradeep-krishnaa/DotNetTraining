using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; } 
        public string? Designation { get; set; } 
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}

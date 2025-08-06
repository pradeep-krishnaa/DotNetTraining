using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Core.DTOs
{
    public class EmployeeRequestDTO //create , update
    {
        public string? EmployeeName { get; set; }
        public string? Designation { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }

    }
}

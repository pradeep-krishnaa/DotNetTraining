using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerGenericRepo.Core.Entities
{
    public class Employee
    {
        //`Id`, `Name`, `Designation`, `DepartmentId`, `Salary`
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTrackerAutoMapper.Core.Entities;

namespace EmployeeTrackerAutoMapper.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}

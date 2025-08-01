﻿using System;
using System.Collections.Generic;

namespace EFCoreDBFirstDemoPhase2.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

using System;
using System.Collections.Generic;

namespace SupportDeskProEF.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();
}

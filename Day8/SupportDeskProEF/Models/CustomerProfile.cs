using System;
using System.Collections.Generic;

namespace SupportDeskProEF.Models;

public partial class CustomerProfile
{
    public int CustomerProfileId { get; set; }

    public int UserId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual User User { get; set; } = null!;
}

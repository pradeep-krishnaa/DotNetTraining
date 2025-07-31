using System;
using System.Collections.Generic;

namespace SupportDeskProEF.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual CustomerProfile? CustomerProfile { get; set; }

    public virtual ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    
}

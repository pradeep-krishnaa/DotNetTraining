using System;
using System.Collections.Generic;

namespace SupportDeskProEF.Models;

public partial class SupportAgent
{
    public int SupportAgentId { get; set; }

    public int UserId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<TicketSupportAgent> AssignedTickets { get; set; } = new List<TicketSupportAgent>(); //added
 
}

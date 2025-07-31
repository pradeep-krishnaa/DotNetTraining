using System;
using System.Collections.Generic;

namespace SupportDeskProEF.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Status { get; set; }

    public int CustomerId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User Customer { get; set; } = null!;
    public virtual ICollection<TicketSupportAgent> TicketSupportAgents { get; set; } = new List<TicketSupportAgent>(); //added


    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();

    public virtual ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();
}

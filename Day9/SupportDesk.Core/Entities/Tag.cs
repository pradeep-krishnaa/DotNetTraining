using System;
using System.Collections.Generic;

namespace SupportDesk.Core.Entities;

public partial class Tag
{
    public int TagId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>(); //added for many-to-many relationship
}

using System;
using System.Collections.Generic;

namespace BugTrackerLite.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreatedDate { get; set; } = DateTime.Now;  //was empty

    public string Status { get; set; } = "Open";  //was null!

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
}

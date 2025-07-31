using System;
using System.Collections.Generic;
namespace SupportDeskProEF.Models;
public class TicketSupportAgent
{
    public int TicketId { get; set; }
    public int SupportAgentId { get; set; }
    public virtual SupportAgent SupportAgent { get; set; } = null!;
    public virtual Ticket Ticket { get; set; } = null!;
}
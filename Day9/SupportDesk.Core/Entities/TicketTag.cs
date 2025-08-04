using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;


namespace SupportDesk.Core.Entities
{
    public class TicketTag
    {
        public int TicketId { get; set; }
        public int TagId { get; set; }
        public virtual Ticket Ticket { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}

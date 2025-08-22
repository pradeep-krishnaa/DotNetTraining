using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.DTOs
{
    public class RegistrationResponseDTO
    {
        // used while fetching registrations
        public int Id { get; set; }
        
        public int UserId { get; set; }
        //public string UserName { get; set; } 
        public int EventId{ get; set; }
        //public string EventName{ get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

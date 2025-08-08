using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.DTOs
{
    public class RegistrationRequestDTO
    {
        // used while creating and updating registrations
        public int UserId { get; set; }
        public UserResponseDTO UserResponseDTO { get; set; }

        public int EventId { get; set; }
        public EventResponseDTO EventResponseDTO { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}

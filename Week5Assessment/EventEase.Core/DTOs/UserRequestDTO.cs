using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.DTOs
{
    public class UserRequestDTO
    {
        // used while creating and updating users
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

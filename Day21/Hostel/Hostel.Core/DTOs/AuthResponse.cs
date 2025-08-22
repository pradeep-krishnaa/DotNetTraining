using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
    }
}

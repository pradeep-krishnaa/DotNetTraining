using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Entities
{
    public class User
    {
        public int Id { get; set; }               
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? PasswordHash { get; set; } = null!;

        // Relationships
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

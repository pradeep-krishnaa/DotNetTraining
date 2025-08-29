using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }                // Primary Key
        public int UserId { get; set; }            // FK → User
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;

        // Navigation
        public User User { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

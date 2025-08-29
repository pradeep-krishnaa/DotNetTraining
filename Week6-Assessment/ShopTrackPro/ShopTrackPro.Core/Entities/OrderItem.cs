using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }                // Primary Key
        public int OrderId { get; set; }           // FK → Order
        public int ProductId { get; set; }         // FK → Product
        public int Quantity { get; set; }

        // Navigation
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}

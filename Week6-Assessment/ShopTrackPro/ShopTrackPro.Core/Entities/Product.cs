﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }                // Primary Key
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;

        // Relationships
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

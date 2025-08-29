using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

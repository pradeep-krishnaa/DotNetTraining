using Microsoft.EntityFrameworkCore;
using SupportDeskEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDeskEF.Models;
using Microsoft.EntityFrameworkCore;

//specially craeted for TicketTag class

namespace SupportDeskEF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Tag> Tags =>  Set<Tag>();
        public DbSet<TicketTag> TicketTags => Set<TicketTag>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskDB;TrustServerCertificate=True;User Id=sa;Password=Pradeep@eps@2520;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });

            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Ticket)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TicketId);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.TicketTags)
                .WithOne(tt => tt.Tag)
                .HasForeignKey(tt => tt.TagId);
        }
    }
}

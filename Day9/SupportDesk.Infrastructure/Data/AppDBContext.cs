using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Core.Entities;

namespace SupportDesk.Infrastructure.Data
{
    public class AppDBContext : CompanyContext
    {
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TicketTag> TicketTags => Set<TicketTag>();
        public DbSet<User> Users => Set<User>();

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

            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TagId);

        }

    }
}

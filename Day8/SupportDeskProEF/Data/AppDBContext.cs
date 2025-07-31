using Microsoft.EntityFrameworkCore;
//using SupportDeskEF.Models;
using SupportDeskProEF.Models;

namespace SupportDeskEF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
        public DbSet<SupportAgent> SupportAgents => Set<SupportAgent>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<TicketHistory> TicketHistories => Set<TicketHistory>();
        public DbSet<TicketSupportAgent> TicketSupportAgents => Set<TicketSupportAgent>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskProDB;TrustServerCertificate=True;User Id=sa;Password=Pradeep@eps@2520;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:1 - User ↔ CustomerProfile
            modelBuilder.Entity<CustomerProfile>()
                .HasOne(cp => cp.User)
                .WithOne(u => u.CustomerProfile)
                .HasForeignKey<CustomerProfile>(cp => cp.UserId);

            // 1:M - User ↔ Tickets (Customer)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Customer)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1:M - Category ↔ Tickets
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1:M - Ticket ↔ TicketHistory
            modelBuilder.Entity<TicketHistory>()
                .HasOne(th => th.Ticket)
                .WithMany(t => t.TicketHistories)
                .HasForeignKey(th => th.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:M - Department ↔ SupportAgents
            modelBuilder.Entity<SupportAgent>()
                .HasOne(sa => sa.Department)
                .WithMany(d => d.SupportAgents)
                .HasForeignKey(sa => sa.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // 1:1 - SupportAgent ↔ User
            modelBuilder.Entity<SupportAgent>()
                .HasOne(sa => sa.User)
                .WithMany(u => u.SupportAgents)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // M:M - Ticket ↔ SupportAgent
            modelBuilder.Entity<TicketSupportAgent>()
                .HasKey(tsa => new { tsa.TicketId, tsa.SupportAgentId });

            modelBuilder.Entity<TicketSupportAgent>()
                .HasOne(tsa => tsa.Ticket)
                .WithMany(t => t.TicketSupportAgents)
                .HasForeignKey(tsa => tsa.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TicketSupportAgent>()
                .HasOne(tsa => tsa.SupportAgent)
                .WithMany(sa => sa.AssignedTickets)
                .HasForeignKey(tsa => tsa.SupportAgentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
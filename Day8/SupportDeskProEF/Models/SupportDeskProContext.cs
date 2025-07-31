using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SupportDeskProEF.Models;

public partial class SupportDeskProContext : DbContext
{
    public SupportDeskProContext()
    {
    }

    public SupportDeskProContext(DbContextOptions<SupportDeskProContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<SupportAgent> SupportAgents { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketHistory> TicketHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskProDB;TrustServerCertificate=True;User Id=sa;Password=Pradeep@eps@2520;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B9C5A2CE9");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CustomerProfile>(entity =>
        {
            entity.HasKey(e => e.CustomerProfileId).HasName("PK__Customer__E4ABBFAB18545106");

            entity.HasIndex(e => e.UserId, "UQ__Customer__1788CC4DD6684007").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.User).WithOne(p => p.CustomerProfile)
                .HasForeignKey<CustomerProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerP__UserI__534D60F1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDAB824DB3");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SupportAgent>(entity =>
        {
            entity.HasKey(e => e.SupportAgentId).HasName("PK__SupportA__6CE2C8A914B57167");

            entity.HasOne(d => d.Department).WithMany(p => p.SupportAgents)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__SupportAg__Depar__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.SupportAgents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupportAg__UserI__5812160E");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC607AAB6F704");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__Categor__5FB337D6");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__Custome__5EBF139D");

            entity.HasMany(d => d.SupportAgents).WithMany(p => p.Tickets)
                .UsingEntity<Dictionary<string, object>>(
                    "TicketSupportAgent",
                    r => r.HasOne<SupportAgent>().WithMany()
                        .HasForeignKey("SupportAgentId")
                        .HasConstraintName("FK__TicketSup__Suppo__6754599E"),
                    l => l.HasOne<Ticket>().WithMany()
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK__TicketSup__Ticke__66603565"),
                    j =>
                    {
                        j.HasKey("TicketId", "SupportAgentId").HasName("PK__TicketSu__F7E2EA8D650DB317");
                        j.ToTable("TicketSupportAgent");
                    });
        });

        modelBuilder.Entity<TicketHistory>(entity =>
        {
            entity.HasKey(e => e.TicketHistoryId).HasName("PK__TicketHi__0CBF57D4AF090DEA");

            entity.Property(e => e.Action).HasMaxLength(200);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketHistories)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__TicketHis__Ticke__6383C8BA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C63EFFC26");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105343AAAE6CD").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

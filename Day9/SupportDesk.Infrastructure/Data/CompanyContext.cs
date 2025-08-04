using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;

namespace SupportDesk.Infrastructure.Data;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskDB;TrustServerCertificate=True;User Id=sa;Password=Pradeep@eps@2520;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9ACD5D2D252");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC60718FA7324");

            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__UserId__398D8EEE");

            entity.HasMany(d => d.Tags).WithMany(p => p.Tickets)
                .UsingEntity<Dictionary<string, object>>(
                    "TicketTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK__TicketTag__TagId__3F466844"),
                    l => l.HasOne<Ticket>().WithMany()
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK__TicketTag__Ticke__3E52440B"),
                    j =>
                    {
                        j.HasKey("TicketId", "TagId").HasName("PK__TicketTa__A77B099DBED72F96");
                        j.ToTable("TicketTags");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C04A15E15");

            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

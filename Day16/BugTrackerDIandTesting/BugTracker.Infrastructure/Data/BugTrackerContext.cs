using BugTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infrastructure.Data
{
    public class BugTrackerContext : DbContext
    {
        //DI using constructor injection
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
        {
        }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configuration can go here
        }
    }
    
}

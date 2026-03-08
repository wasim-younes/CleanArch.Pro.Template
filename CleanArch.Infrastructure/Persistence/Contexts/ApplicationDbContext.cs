using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // This creates the "Members" table in SQL
        public DbSet<Member> Members => Set<Member>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pro Tip: This is where you configure Value Objects (Address)
            // to be saved as columns inside the Members table.
            modelBuilder.Entity<Member>().OwnsOne(m => m.HomeAddress);

            base.OnModelCreating(modelBuilder);
        }
    }
}

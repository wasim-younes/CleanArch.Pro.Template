using CleanArch.Domain.Entities;
using CleanArch.Domain.ValueObjects;
using CleanArch.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Members.Any()) return;

            var seedMember = new Member("John", "Doe", "john.doe@example.com");
            seedMember.UpdateAddress(new Address("123 Main St", "New York","us_state", "10001","usa"));

            context.Members.Add(seedMember);
            context.SaveChanges();
        }
    }
}

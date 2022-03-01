using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPS.Data.Extensions;
using SPS.Data.Models.Entities;
using SPS.Data.Models.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<Account, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.SeedUserRole();

            base.OnModelCreating(builder);
        }
    }
}

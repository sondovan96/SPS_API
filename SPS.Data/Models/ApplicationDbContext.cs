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
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<FavoriteProduct> FavoriteProduct { set; get; }
        public DbSet<Promotion> Promotions { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new PromotionConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());

            builder.SeedUserRole();

            base.OnModelCreating(builder);
        }
    }
}

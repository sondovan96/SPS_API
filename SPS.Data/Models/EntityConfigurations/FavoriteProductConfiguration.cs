using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class FavoriteProductConfiguration : IEntityTypeConfiguration<FavoriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
        {
            builder.ToTable("FavoriteProduct");

            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.FavoriteProduct)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.FavoriteProduct)
                .HasForeignKey(x => x.AccountId);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

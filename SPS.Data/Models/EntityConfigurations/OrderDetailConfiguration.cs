using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");

            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Order)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(x => x.OrderId);
            builder.HasOne(c => c.Product)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

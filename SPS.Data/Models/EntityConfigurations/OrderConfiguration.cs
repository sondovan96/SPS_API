using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Account)
                .WithMany(c => c.Orders)
                .HasForeignKey(x => x.UserId);
        }
    }
}

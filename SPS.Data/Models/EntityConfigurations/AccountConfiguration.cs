using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Extensions;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.EntityConfigurations
{
    public class AccountConfiguration:IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.FirstName)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(a => a.FullName)
                .HasComputedColumnSql("[FirstName]+' '+[LastName]");

            builder.Property(a => a.CreatedDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(a => a.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(a => a.Gender)
                .IsRequired();

            builder.SeedUser();
        }
    }
}

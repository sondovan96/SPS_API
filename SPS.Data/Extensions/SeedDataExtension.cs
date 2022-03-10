using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Extensions
{
    public static class SeedDataExtension
    {
        private static readonly List<Account> _accounts = new List<Account>()
        {
            
            new Account()
            {
                Id = new Guid("6FCBE5A2-5C73-42FB-B334-748FFC143060"),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com".ToUpper(),
                PhoneNumber = "123456",
                FirstName = "Default",
                LastName = "Admin",
                ModifiedDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Gender = false
            }
        };

        private static readonly List<Role> _roles = new List<Role>()
        {
            new Role()
            {
                Id = new Guid("E9715A27-60A4-4F3E-A0C9-AC1765CD4126"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new Role()
            {
                Id = new Guid("BCC8996D-FF06-4519-A009-F7CF3BE4FF45"),
                Name = "Customer",
                NormalizedName = "Customer".ToUpper()
            }
        };


        public static void SeedRole(this EntityTypeBuilder<Role> builder)
        {
            builder.HasData(_roles);
        }


        public static void SeedUser(this EntityTypeBuilder<Account> builder)
        {
            foreach (var account in _accounts)
            {
                PasswordHasher<Account> passwordHasher = new PasswordHasher<Account>();
                account.PasswordHash = passwordHasher.HashPassword(account, $"{account.UserName}@123");
            }

            builder.HasData(_accounts);
        }
        public static void SeedUserRole(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>()
                {
                    UserId = _accounts[0].Id,
                    RoleId = _roles[0].Id
                });
        }
    }
}

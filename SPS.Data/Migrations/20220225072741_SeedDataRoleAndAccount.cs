using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class SeedDataRoleAndAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"), "1a66938f-54e8-435c-846f-54901086e1c7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"), "19f09bcc-c4aa-4505-a166-a574c4877efb", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DepartmentId", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"), 0, "984d8b7e-dcc1-489d-bf1d-b477da2eabe6", new DateTime(2022, 2, 25, 14, 27, 41, 376, DateTimeKind.Local).AddTicks(7485), new Guid("00000000-0000-0000-0000-000000000000"), "admin@example.com", false, "Default", false, false, "Admin", false, null, new DateTime(2022, 2, 25, 14, 27, 41, 375, DateTimeKind.Local).AddTicks(8108), "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEOPgXs0BlCaJqRHP70GkbE9kl0ovW4cM1Y95jVyInwYikZGneYiRQqyJo5aT1/exDw==", "123456", false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"), new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"), new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"));
        }
    }
}

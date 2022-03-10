using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class RemoveDepartmentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "dec4b322-e86f-4831-bbe6-1bfb7882d8f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "c57c78f7-9907-488a-9c80-b9e41c9d53f2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "d47f7f3c-eba1-4ffb-ba9f-bc1a25678790", new DateTime(2022, 3, 9, 15, 31, 20, 355, DateTimeKind.Local).AddTicks(3831), new DateTime(2022, 3, 9, 15, 31, 20, 354, DateTimeKind.Local).AddTicks(6805), "AQAAAAEAACcQAAAAEOgv7bnG3kebEj8oln9x7tH6IdyNZBMUxKhpzG2iRklGnKYUOVe4D5VUJKUSbFhFKg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "e835e2a1-6b6f-4706-9675-a4f37fb80cef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "6f2f641d-9e50-4fd5-9dd6-34f917621e49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "b1c3b38c-59c0-4d58-a555-3c4393fc06f4", new DateTime(2022, 3, 4, 23, 44, 16, 732, DateTimeKind.Local).AddTicks(1708), new DateTime(2022, 3, 4, 23, 44, 16, 731, DateTimeKind.Local).AddTicks(4376), "AQAAAAEAACcQAAAAENBvi9gbaEOX2IYgedmol01gwtSBqHmi6Q+tgQ1DRebM5f+2yO0S7qTqX0QjQWumhQ==" });
        }
    }
}

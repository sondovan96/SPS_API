using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class UpdateFavoriteProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "b08ff33e-d693-42e3-8865-a5328b2e3125");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "c1f02a20-5d92-4233-98ca-1b031ef7a17b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "4d2eb05f-a2f6-48ff-8fa5-357bdda5dd82", new DateTime(2022, 3, 17, 0, 4, 49, 260, DateTimeKind.Local).AddTicks(2467), new DateTime(2022, 3, 17, 0, 4, 49, 259, DateTimeKind.Local).AddTicks(1327), "AQAAAAEAACcQAAAAEJD2iRYmT60GeAefgI+Mufp48Z3qhBkdKPv7mLm9Ib84/KZ6JvGpAzDlO/DhuzZqAw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "8a10ea5b-f347-47a7-85d2-a625170958a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "349aaa41-0720-49c3-a0d4-de516201ce79");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "3a28e712-f84b-4303-ac0f-e9add40a9cdb", new DateTime(2022, 3, 17, 0, 0, 0, 355, DateTimeKind.Local).AddTicks(6647), new DateTime(2022, 3, 17, 0, 0, 0, 354, DateTimeKind.Local).AddTicks(2902), "AQAAAAEAACcQAAAAEKIe0w62ug11XXlBB2HbDTDfaWApnh79RIhlibpv/trlecoUEViYHe5CtVmHqXU00w==" });
        }
    }
}

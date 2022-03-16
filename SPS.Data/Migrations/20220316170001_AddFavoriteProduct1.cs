using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class AddFavoriteProduct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "d05e7d4a-6e7c-4c42-a293-bc1e064a3713");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "a26dcd21-239c-473a-bed3-c44fe182e389");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "61e19e08-7382-46ee-989d-255846714cb2", new DateTime(2022, 3, 16, 23, 53, 55, 80, DateTimeKind.Local).AddTicks(5043), new DateTime(2022, 3, 16, 23, 53, 55, 79, DateTimeKind.Local).AddTicks(2246), "AQAAAAEAACcQAAAAEAqsaatIRUW4GoSqI56UJcUwpS3BoTzyUTp1G/VdiZd2WO7Z9XF5vyqqvzNbYG4bgQ==" });
        }
    }
}

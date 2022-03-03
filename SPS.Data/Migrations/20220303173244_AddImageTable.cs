using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class AddImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "5d179868-3275-464b-aa9c-cd1e768577fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "5ffe5615-db59-4578-820f-6f5ee9f855e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "5a38512b-aca7-48d2-860c-ed252c0ea225", new DateTime(2022, 3, 4, 0, 32, 43, 509, DateTimeKind.Local).AddTicks(4935), new DateTime(2022, 3, 4, 0, 32, 43, 508, DateTimeKind.Local).AddTicks(7047), "AQAAAAEAACcQAAAAEHSvraDVMJ/OR1cHeyaxh2m2IPN1Lb4eriX4AyQDtrDIYXy36W7FFZOViD0k1m56cA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "4bc7b411-66d0-47f7-b99e-7f3a58984dbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "6c0f6db8-6f07-45e8-85bf-8c955cee7aae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "c8ca5f9a-1027-4d9c-b082-243e0f975c96", new DateTime(2022, 3, 3, 17, 7, 29, 89, DateTimeKind.Local).AddTicks(7993), new DateTime(2022, 3, 3, 17, 7, 29, 89, DateTimeKind.Local).AddTicks(396), "AQAAAAEAACcQAAAAEMb9mb3NnluEnn8jmFG2Zr/FQ4cblXFNaSTch76ECpi3JtTt2enPH2X9IutJiz7Srg==" });
        }
    }
}

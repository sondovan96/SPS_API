using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class FixOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "f5599a1b-85c5-4b58-8dcc-3b5dee439921");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "6164b6ce-8631-4222-a20d-434593e5544b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "1dd9a970-2435-4bcc-8b2e-a982df08194e", new DateTime(2022, 3, 26, 6, 24, 26, 850, DateTimeKind.Local).AddTicks(439), new DateTime(2022, 3, 26, 6, 24, 26, 848, DateTimeKind.Local).AddTicks(9627), "AQAAAAEAACcQAAAAEF9pZbBgvWEjJJyIwgDixQ9bPQDcRFFSyR1ZjQNcX9GZVMl5l4qj5KLUhcQ0XM4/SQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

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
    }
}

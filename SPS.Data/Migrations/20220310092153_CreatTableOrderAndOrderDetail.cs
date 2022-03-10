using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class CreatTableOrderAndOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    PaymentIntentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "7249af43-22ba-44eb-87d2-8be545800498");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "6fc5fad7-77de-4bc2-aa08-0d3256c1a576");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "0783e5a2-5658-40ad-b0b8-4bdac869bda5", new DateTime(2022, 3, 10, 16, 21, 52, 543, DateTimeKind.Local).AddTicks(3943), new DateTime(2022, 3, 10, 16, 21, 52, 542, DateTimeKind.Local).AddTicks(6566), "AQAAAAEAACcQAAAAENiIbMsCHXHnc/ojeSfCY0IW+upN4VM0RQHpQBTkhlkoozyfWRnFpPw0b2p3N8Fl1w==" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountId",
                table: "Order",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

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
    }
}

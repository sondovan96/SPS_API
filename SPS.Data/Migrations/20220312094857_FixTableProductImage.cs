using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class FixTableProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "5420335d-7a47-40eb-9d68-3caa9dd5dc94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "47ab1ab0-1340-442f-b346-653aa1f22a09");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "316826fe-01b1-493a-932b-cbe020c3dc23", new DateTime(2022, 3, 12, 16, 48, 56, 565, DateTimeKind.Local).AddTicks(1822), new DateTime(2022, 3, 12, 16, 48, 56, 564, DateTimeKind.Local).AddTicks(4358), "AQAAAAEAACcQAAAAEA+YGtAMDAgcyDM9BTXvkEU+knumoYgHjNBa+CfxZgLzITGOMlwnJnJz7ZnyRDfx/w==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImage",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcc8996d-ff06-4519-a009-f7cf3be4ff45"),
                column: "ConcurrencyStamp",
                value: "36a913d8-d8f9-4c29-838d-ede0b62055e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9715a27-60a4-4f3e-a0c9-ac1765cd4126"),
                column: "ConcurrencyStamp",
                value: "66766dd7-e266-475d-9cc3-bc63e6443f28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fcbe5a2-5c73-42fb-b334-748ffc143060"),
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "ModifiedDate", "PasswordHash" },
                values: new object[] { "88a4fdc4-9ff0-4864-870b-10c67f8b3012", new DateTime(2022, 3, 12, 16, 47, 34, 950, DateTimeKind.Local).AddTicks(200), new DateTime(2022, 3, 12, 16, 47, 34, 949, DateTimeKind.Local).AddTicks(2839), "AQAAAAEAACcQAAAAEMSgQFemtu6eqGjLz7hRrxs4cBQzDXd5UuOF6WcN1auie1M2iP6oQPdVuiKvQsEX4w==" });
        }
    }
}

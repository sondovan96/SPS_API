using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Data.Migrations
{
    public partial class AddFavoriteProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Product_ProductId",
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

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_AccountId",
                table: "FavoriteProduct",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_ProductId",
                table: "FavoriteProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteProduct");

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
        }
    }
}
